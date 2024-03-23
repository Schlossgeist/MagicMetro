using System;
using System.Text;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Schlossgeist.MagicMetro
{
    public class Logger
    {
        private readonly FileInfo logFile;
        private StreamWriter writer;
        private ulong logNumber = 0;

        public Logger(string path)
        {
            if (!File.Exists(path)) File.Create(path).Close();
            logFile = new FileInfo(path);
            writer = null;

            var lines = File.ReadAllLines(logFile.FullName);
            int clearUntil = -1;
            for (int i = lines.Length - 1; i >= 0; i--)
            {
                string line = lines[i];
                if (line.StartsWith("Log #"))
                {
                    if (clearUntil == -1)
                    {
                        logNumber = ulong.Parse(line.Remove(0, 5)) + 1;
                        clearUntil = 0;
                    }
                    else
                    {
                        // keep the last four logs plus the one for the current session
                        if (logNumber - 3 > ulong.Parse(line.Remove(0, 5)))
                        {
                            clearUntil = i;
                            break;
                        }
                    }
                }
            }

            if (clearUntil > 0) File.WriteAllLines(logFile.FullName, lines.Skip(clearUntil));
        }

        private void Write(string ident, string message)
        {
            if (writer == null)
            {
                writer = new StreamWriter(logFile.FullName, true, Encoding.UTF8);
                writer.AutoFlush = false;
                writer.WriteLine($"Log #{logNumber}");
            }
            writer.WriteLine($"{DateTime.Now:s} [{ident}]: {message}");
            writer.Flush();
        }

        public void Close()
        {
            if (writer == null) return;
            try
            {
                writer.Close();
            }
            catch (ObjectDisposedException)
            {}
        }

        public void Debug(string text,
            [CallerFilePath] string file = "",
            [CallerMemberName] string member = "",
            [CallerLineNumber] int line = 0)
        {
            Write($"DBG/{Path.GetFileName(file)}_{member}({line})", text);
        }

        public void Info(string text,
            [CallerFilePath] string file = "",
            [CallerMemberName] string member = "",
            [CallerLineNumber] int line = 0)
        {
            Write($"IFO/{Path.GetFileName(file)}_{member}({line})", text);
        }

        public void Warn(string text,
            [CallerFilePath] string file = "",
            [CallerMemberName] string member = "",
            [CallerLineNumber] int line = 0)
        {
            Write($"WRN/{Path.GetFileName(file)}_{member}({line})", text);
        }

        public void Error(string text,
            [CallerFilePath] string file = "",
            [CallerMemberName] string member = "",
            [CallerLineNumber] int line = 0)
        {
            Write($"ERR/{Path.GetFileName(file)}_{member}({line})", text);
        }
    }
}
