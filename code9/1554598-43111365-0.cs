    using System;
    using System.IO;
    using System.Diagnostics;
    namespace StackOverflow_FileNameShenanigans
    {
        class Program
        {
            static void Main(string[] args)
            {
                string contents;
                DateTime origAccessDate;
                DateTime origCreateDate;
                long sizeBytes;
                string path = @"\\?\C:\Test\BadFileName.";
                try
                {
                    contents = CommandLineFileOps.ReadAllText(path);
                    origAccessDate = CommandLineFileOps.LastAccessTime(path);
                    origCreateDate = CommandLineFileOps.CreationTime(path);
                    sizeBytes = CommandLineFileOps.Length(path);
                    Console.WriteLine($"Contents: {contents}");
                    Console.WriteLine($"OrigAccessDate: {origAccessDate}");
                    Console.WriteLine($"OrigCreateDate: {origCreateDate}");
                    Console.WriteLine($"SizeBytes: {sizeBytes}");
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    Console.ReadKey();
                }
            }
        }
        public static class CommandLineFileOps
        {
            public static string ReadAllText(string path)
            {
                string contents;
                RunOnCommandLine($"type {path}", out contents);
                contents = contents.Substring(0, contents.Length - 3);
                return contents;
            }
            public static DateTime CreationTime(string path)
            {
                string output;
                RunOnCommandLine($"dir /T:C {path}", out output);
                string dateLine = output.Split('\n')[5];
                string dateStr = dateLine.Replace("                 ", "\n").Split('\n')[0];
                return DateTime.Parse(dateStr);
            }
            public static DateTime LastAccessTime(string path)
            {
                string output;
                RunOnCommandLine($"dir /T:A {path}", out output);
                string dateLine = output.Split('\n')[5];
                string dateStr = dateLine.Replace("                 ", "\n").Split('\n')[0];
                return DateTime.Parse(dateStr);
            }
            public static long Length(string path)
            {
                string output;
                RunOnCommandLine($"dir {path}", out output);
                string lengthLine = output.Split('\n')[6];
                string lengthStr = lengthLine.Replace("              ", "\n").Split('\n')[2].Split(' ')[0];
                return long.Parse(lengthStr);
            }
            private static int RunOnCommandLine(string line)
            {
                Process cmd = new Process();
                cmd.StartInfo.FileName = "cmd.exe";
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.UseShellExecute = false;
                cmd.Start();
                cmd.StandardInput.WriteLine(line);
                cmd.StandardInput.Flush();
                cmd.StandardInput.Close();
                cmd.WaitForExit();
                int exitCode = cmd.ExitCode;
                return exitCode;
            }
            private static int RunOnCommandLine(string line, out string output)
            {
                string tempPath = Path.GetTempFileName();
                int exitCode = RunOnCommandLine($"{line} > {tempPath}");
                output = File.ReadAllText(tempPath);
                File.Delete(tempPath);
                return exitCode;
            }
        }
    }
