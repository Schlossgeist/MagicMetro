using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;
using IP = Schlossgeist.MagicMetro.ImageProcessing;

namespace Schlossgeist.MagicMetro
{
    public class Config
    {
        private readonly Logger logger;
        private readonly IDeserializer deserializer;

        public readonly FileInfo configFile;

        public class Configuration
        {
            public class XMLReplacement
                {
                    public class TextPosition
                    {
                        public class TextPositionConverter : IYamlTypeConverter
                        {
                            public static readonly IYamlTypeConverter Instance = new TextPositionConverter();

                            public bool Accepts(Type type)
                            {
                                return type == typeof(TextPosition);
                            }

                            public object? ReadYaml(IParser parser, Type type)
                            {
                                string raw = parser.Consume<Scalar>().Value;
                                char[] splitChars = { 'L', 'C' };
                                var numStrings = raw.Split(splitChars);

                                var textPos = new TextPosition() { line = Int32.Parse(numStrings[1]), col = Int32.Parse(numStrings[2]) };

                                return textPos;
                            }

                            public void WriteYaml(IEmitter emitter, object? value, Type type)
                            {
                                TextPosition textPosition = (TextPosition) value!;

                                emitter.Emit(new Scalar($"L{textPosition.line} C{textPosition.col}"));
                            }
                        }

                        public int line;
                        public int col;

                        public override string ToString() {
                            return $"L{line} C{col}";
                        }
                    }

                    public string path;
                    public Dictionary<TextPosition, string> replacements;
                }

            public class XMLCReplacement
                {
                    public class Source
                    {
                        public string color;
                        public string source;
                        public int saturation;
                        public int brightness;
                    }

                    [YamlMember(Alias = "source-path", ApplyNamingConventions = false)]
                    public string sourcePath;
                    [YamlMember(Alias = "destination-path", ApplyNamingConventions = false)]
                    public string destinationPath;
                    public Dictionary<string, Source> replacements;
                }

            [YamlMember(Alias = "custom-color", ApplyNamingConventions = false)]
            public IP.Color customColor;

            [YamlMember(Alias = "install-path", ApplyNamingConventions = false)]
            public string installPath;

            [YamlMember(Alias = "xml-replace-jobs", ApplyNamingConventions = false)]
            public List<XMLReplacement> xmlReplaceJobs;

            [YamlMember(Alias = "xmlc-replace-jobs", ApplyNamingConventions = false)]
            public List<XMLCReplacement> xmlcReplaceJobs;
        }

        public Configuration configuration;

        public Config(MagicMetro magicMetro, string path)
        {
            logger = magicMetro.getLogger();
            deserializer = new DeserializerBuilder()
                .WithTypeConverter(ImageProcessing.Color.ColorConverter.Instance)
                .WithTypeConverter(Configuration.XMLReplacement.TextPosition.TextPositionConverter.Instance)
                .Build();

            if (!File.Exists(path))
            {
                File.WriteAllText(path, "custom-color: (0,0,0)\ninstall-path: \nxml-replace-jobs:\nxmlc-replace-jobs:");
                logger.Info($"No config file has been found. A new config file has been created at {path}");
            }

            configFile = new FileInfo(path);

            readConfigFile();
            magicMetro.customColor = configuration.customColor;
        }

        public void readConfigFile()
        {
            var reader = new StreamReader(configFile.OpenRead());
            configuration = deserializer.Deserialize<Configuration>(reader);
            reader.Close();
        }

        private bool isValidAddress(string address)
        {
            var validChars = new HashSet<char>
            {
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
                'A', 'B', 'C', 'D', 'E', 'F'
            };

            foreach (var character in address)
            {
                if (!validChars.Contains(character)) return false;
            }

            return true;
        }

        public void writeCustomColorToConfig(IP.Color color)
        {
            string[] lines = File.ReadAllLines(Path.Combine(configFile.FullName));

            for (int lineIndex = 0; lineIndex < lines.Length; lineIndex++)
            {
                if (lines[lineIndex].Contains("custom-color: "))
                {
                    lines[lineIndex] = $"custom-color: ({color.R},{color.G},{color.B})";
                    File.WriteAllLines(configFile.FullName, lines);
                    logger.Info($"Wrote custom color {color} to config file {configFile.FullName} at line {lineIndex}");
                    break;
                }
            }
        }

        public void writeInstallationPathToConfig(string path)
        {
            string[] lines = File.ReadAllLines(Path.Combine(configFile.FullName));

            for (int lineIndex = 0; lineIndex < lines.Length; lineIndex++)
            {
                if (lines[lineIndex].Contains("install-path: "))
                {
                    lines[lineIndex] = $"install-path: {path}";
                    File.WriteAllLines(configFile.FullName, lines);
                    logger.Info($"Wrote install path {path} to config file {configFile.FullName} at line {lineIndex}");
                    break;
                }
            }
        }
    }
}
