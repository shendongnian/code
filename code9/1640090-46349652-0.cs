    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    using System.Timers;
    
    namespace bufferOutput
    {
        public class Processor
        {
            private object bufferLock = new object();
            private StringBuilder sb = new StringBuilder();
            private Timer updateTime = new Timer(250);//fire every quarter second: a reasonable time for a web page to update
            
            public void Execute(string fileName, string args)
            {
                var process = new Process { StartInfo = { FileName = fileName, Arguments = args } };
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.EnableRaisingEvents = true;
                process.Exited += ProcessExited;
                process.OutputDataReceived += AppendOutput;
                process.Start();
                updateTime.Elapsed += updateTime_Elapsed;
                process.BeginOutputReadLine();
                updateTime.Start();
                Console.Title = "Buffered data: Press the Enter key to exit the program.";
                Console.ReadLine();
                ProcessExited(this, EventArgs.Empty);
                Console.ReadLine();
            }
    
            void updateTime_Elapsed(object sender, ElapsedEventArgs e)
            {
                string output = "";
                lock(bufferLock)
                {
                    output = sb.ToString();
                    if (output != "")//if there was anything in the strng builder, clear it
                        sb = new StringBuilder();
                }
                if (output != "")
                    SendOutput(output);
            }
    
            public void ProcessExited(object sender, EventArgs e)
            {
                updateTime.Stop();
                Console.Title = "writing out buffer: Press the Enter key to exit the program.";
                updateTime_Elapsed(this, null);
                SendOutput("Done");
            }
    
            public void AppendOutput(object sender, DataReceivedEventArgs e)
            {
                if (e.Data != null)
                {
                    lock (bufferLock)
                        sb.AppendLine(e.Data);
                }
            }
    
            public void SendOutput(string output)//placeholder for the client side
            {
                Console.WriteLine(output);
            }
        }
    }
