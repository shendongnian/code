    using System;
    using System.Diagnostics;
    namespace so45176273
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                var startInfo = new ProcessStartInfo("cmd")
                {
                    WorkingDirectory = @"c:\Trash",
                    Arguments = "/k" // will leave the process running until you type exit
                };
                Process.Start(startInfo);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
