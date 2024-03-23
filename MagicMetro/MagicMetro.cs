using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Windows.UI.ViewManagement;
using MusicBeePlugin;

using IP = Schlossgeist.MagicMetro.ImageProcessing;

namespace Schlossgeist.MagicMetro
{
    public class MagicMetro
    {
        public Dictionary<string, IP.Color> colorDict = new Dictionary<string, IP.Color>();

        private readonly UISettings uiSettings;

        private readonly string name;
        private readonly string configFolder;
        private readonly string installationFolder;
        private readonly Logger logger;
        private readonly Config config;
        private readonly Plugin plugin;

        public IP.Color customColor;

        public MagicMetro(string configurationPath, Plugin plugin)
        {
            Assembly asm = Assembly.GetAssembly(GetType());
            name = asm.GetName().Name;
            configFolder = Path.Combine(configurationPath, name);

            uiSettings = new UISettings();
            updateColorDict();
            uiSettings.ColorValuesChanged += (sender, args) =>
            {
                updateColorDict();
                plugin.configPanel.reloadColors(colorDict);
            };

            Directory.CreateDirectory(configFolder);
            logger = new Logger(Path.Combine(configFolder, name + ".log"));
            config = new Config(this, Path.Combine(configFolder, "config.yml"));
            updateColorDict();
            this.plugin = plugin;

            DirectoryInfo di = new DirectoryInfo(configurationPath);

            if (di.Parent != null)
            {
                if (di.Parent.GetDirectories().Any(dir => dir.Name == "AppData"))
                {
                    installationFolder = di.Parent.FullName;
                    logger.Info("Portable mode");
                }
                else
                {
                    if (config.configuration.installPath != null && Directory.Exists(config.configuration.installPath))
                    {
                        installationFolder = config.configuration.installPath;
                    }
                    else
                    {
                        MessageBox.Show("The plugin has detected that you are using the non-portable version of MusicBee.\n" +
                                        "For the plugin to work correctly, you have to provide the installation directory of MusicBee.", "MagicMetro");
                        var folderBrowserDialog = new FolderBrowserDialog();
                        folderBrowserDialog.Description = "Choose the installation directory of MusicBee";
                        folderBrowserDialog.ShowNewFolderButton = false;

                        if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                        {
                            installationFolder = folderBrowserDialog.SelectedPath;
                            config.writeInstallationPathToConfig(installationFolder);
                        }

                        logger.Info($"Provided installation path: {installationFolder}");
                    }

                    logger.Info("Install mode");
                }
            }

            logger.Info($"Plugin started successfully");
        }

        ~MagicMetro()
		{
            shutdown();
        }

        public Logger getLogger()
        {
            return logger;
        }

        public Config getConfig()
        {
            return config;
        }

        public string getInstallationPath()
        {
            return installationFolder;
        }

        public void extractImages()
        {
            var di = Directory.CreateDirectory(Path.Combine(configFolder, "extractedImages"));
            var xmlcNodes = config.configuration.xmlcReplaceJobs;

            foreach (var xmlcNode in xmlcNodes)
            {
                string sourceFileName = xmlcNode.sourcePath.Split('\\').ToList().Last();
                string destinationDirectory = Directory.CreateDirectory(Path.Combine(di.FullName, sourceFileName)).FullName;

                extractImagesFromFile(Path.Combine(installationFolder, xmlcNode.sourcePath), destinationDirectory);
            }
        }

        public void extractImagesFromFile(string sourcePath, string destinationDirectory)
        {
            string PNG_HEADER = "89504e47";
            string PNG_FOOTER = "49454e44ae426082";
            Regex regex = new Regex(PNG_HEADER + "(.*?)" + PNG_FOOTER);

            byte[] bytes = File.ReadAllBytes(sourcePath);
            string bytesString = bytesToString(bytes);

            var matches = regex.Matches(bytesString);
            int i = 0;

            foreach (Match match in matches)
            {
                string png = match.Groups[0].ToString();
                byte[] png_raw = stringToBytes(png);

                int offset = match.Index / 2;

                string fileName = $"extractID_{offset:X}.png";

                File.WriteAllBytes(Path.Combine(destinationDirectory, fileName), png_raw);
                i++;
            }

            MessageBox.Show($"Extracted {i} images to {destinationDirectory}", "Images Extracted");
        }

        public void writeImagesToFile(string sourcePath, string destPath, Dictionary<string, Config.Configuration.XMLCReplacement.Source> replacements)
        {
            var offsetToOriginalRaw = new Dictionary<string, byte[]>();
            var destStringToNewString = new Dictionary<string, string>();

            string PNG_HEADER = "89504e47";
            string PNG_FOOTER = "49454e44ae426082";
            Regex regex = new Regex(PNG_HEADER + "(.*?)" + PNG_FOOTER);

            byte[] bytes = File.ReadAllBytes(sourcePath);
            string bytesString = bytesToString(bytes);

            var matches = regex.Matches(bytesString);

            foreach (Match match in matches)
            {
                string png = match.Groups[0].ToString();
                byte[] png_raw = stringToBytes(png);

                int offset = match.Index / 2;
                offsetToOriginalRaw[$"{offset:X}"] = png_raw;
            }

            string new_hex = bytesString;

            foreach (var kvp in replacements)
            {
                var source = kvp.Value;
                string dest = kvp.Key;

                IP.Color highlightColor = colorDict[source.color];

                byte[,] lutRGBA = new byte[3, 256];

                for (int channel = 0; channel < 3; channel++)
                {
                    for (int value = 0; value < 256; value++)
                    {
                        lutRGBA[channel,value] = (byte) (value * highlightColor[channel] / 255);
                    }
                }

                string address = source.source ?? dest;
                if (!offsetToOriginalRaw.ContainsKey(address))
                    throw new Exception($"the image corresponding to ID {address} can not be found in {sourcePath}");

                var image = (Bitmap) new ImageConverter().ConvertFrom(offsetToOriginalRaw[address]);

                var oldHighlightColor = IP.GetHighlightColor(image);
                var (hasSolidBackground, backgroundColor) = IP.HasSolidBackground(image);
                var mask = hasSolidBackground ? IP.ColorMask(image, backgroundColor, false, 5) : null;

                if (oldHighlightColor.S <= 0.01)
                    image = IP.Point(image, lutRGBA, false, mask);
                else
                    image = IP.Rotate(image, highlightColor.H - oldHighlightColor.H, mask);

                if (source.saturation != 0) image = IP.Saturate(image, source.saturation / 100F, mask);
                if (source.brightness != 0) image = IP.Brighten(image, source.brightness / 100F, mask);

                var imageBytes = new MemoryStream();
                image.Save(imageBytes, ImageFormat.Png);

                string destString = dest + bytesToString(offsetToOriginalRaw[dest]);
                string imageString = bytesToString(imageBytes.ToArray());

                destStringToNewString[destString] = imageString;
            }

            int i = 0;
            foreach (var kvp in destStringToNewString)
            {
                string original = kvp.Key.Substring(4);
                string replacement = kvp.Value;
                new_hex = new_hex.Replace(original, replacement);
                var indices = Regex.Matches(new_hex, replacement);

                foreach (Match index in indices)
                {
                    string head = new_hex.Substring(0, index.Index - 8);
                    string length = string.Empty;
                    foreach (byte b in BitConverter.GetBytes(Convert.ToInt32(replacement.Length / 2)))
                        length += b.ToString("X2");
                    string tail = new_hex.Substring(index.Index);

                    new_hex = head + length + tail;
                }

                i++;
            }

            File.WriteAllBytes(destPath, stringToBytes(new_hex));
        }

        public void writeColorToFile(string path, Dictionary<Config.Configuration.XMLReplacement.TextPosition, string> colorDictionary)
        {
            string[] lines = File.ReadAllLines(Path.Combine(installationFolder, path));

            foreach (var textPos in colorDictionary.Keys)
            {
                string oldLine = lines[textPos.line-1];
                string oldText = oldLine[textPos.col-1].ToString();
                string newLine = oldLine;

                for (int i = textPos.col; i < oldLine.Length; i++)
                {
                    oldText += oldLine[i];

                    if (oldLine[i].Equals('\"'))
                    {
                        var color = colorDict[colorDictionary[textPos]];

                        newLine = newLine.Replace(oldText, $"\"{color.R},{color.G},{color.B}\"");
                        lines[textPos.line-1] = newLine;
                        break;
                    }
                }
            }

            File.WriteAllLines(Path.Combine(installationFolder, path), lines);
        }

        public void shutdown()
        {
            config.readConfigFile();

            foreach (var xmlNode in config.configuration.xmlReplaceJobs ?? new List<Config.Configuration.XMLReplacement>())
            {
                writeColorToFile(xmlNode.path, xmlNode.replacements);
            }

            foreach (var xmlcNode in config.configuration.xmlcReplaceJobs ?? new List<Config.Configuration.XMLCReplacement>())
            {
                writeImagesToFile(Path.Combine(installationFolder, xmlcNode.sourcePath),
                    Path.Combine(installationFolder, xmlcNode.destinationPath),
                    xmlcNode.replacements);
            }

            config.writeCustomColorToConfig(customColor);
            config.writeInstallationPathToConfig(installationFolder);

            logger.Close();
        }

        public void uninstall()
        {
        }

        public void updateColorDict()
        {
            var colorTypes = new List<string>() {
                "background", "foreground",
                "accent-dark3", "accent-dark2", "accent-dark1",
                "accent",
                "accent-light1", "accent-light2", "accent-light3"
            };

            for (int i = 0; i < 9; i++)
            {
                colorDict[colorTypes[i]] = new IP.Color(uiSettings.GetColorValue((UIColorType) i));
            }

            colorDict["custom"] = customColor;
        }

        public void onCustomColorChange(IP.Color color)
        {
            customColor = color;
        }

        private string bytesToString(byte[] bytes)
        {
            StringBuilder hex = new StringBuilder(bytes.Length * 2);
            foreach (byte b in bytes) hex.AppendFormat("{0:x2}", b);

            return hex.ToString();
        }

        private byte[] stringToBytes(string hexString)
        {
            int NumberChars = hexString.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hexString.Substring(i, 2), 16);
            return bytes;
        }
    }
}
