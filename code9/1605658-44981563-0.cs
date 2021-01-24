    using System;
    using System.Diagnostics;
    
    namespace ConvertMP4ToMP3
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                var inputFile = args[0] + ".mp4";
                var outputFile = args[1] + ".mp3";
                var mp3out = "";
                var ffmpegProcess = new Process();
                ffmpegProcess.StartInfo.UseShellExecute = false;
                ffmpegProcess.StartInfo.RedirectStandardInput = true;
                ffmpegProcess.StartInfo.RedirectStandardOutput = true;
                ffmpegProcess.StartInfo.RedirectStandardError = true;
                ffmpegProcess.StartInfo.CreateNoWindow = true;
                ffmpegProcess.StartInfo.FileName = "//path/to/ffmpeg";
                ffmpegProcess.StartInfo.Arguments = " -i " + inputFile + " -vn -f mp3 -ab 320k output " + outputFile;
                ffmpegProcess.Start();
                ffmpegProcess.StandardOutput.ReadToEnd();
                mp3out = ffmpegProcess.StandardError.ReadToEnd();
                ffmpegProcess.WaitForExit();
                if (!ffmpegProcess.HasExited)
                {
                    ffmpegProcess.Kill();
                }
                Console.WriteLine(mp3out);
            }
        }
    }
