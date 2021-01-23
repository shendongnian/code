    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Diagnostics;
    using System.IO;
    
    namespace ConsoleApplication_FFmpegDemo
    {
        public class FFmpegTask
        {
            public Process process = new Process();
    
            public FFmpegTask(string ffmpegPath, string arguments)
            {
                process.StartInfo.FileName = ffmpegPath;
                process.StartInfo.Arguments = arguments;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.CreateNoWindow = false;
                process.StartInfo.UseShellExecute = false;
            }
    
            public bool Start()
            {
                return process.Start();
            }
        }
    }
