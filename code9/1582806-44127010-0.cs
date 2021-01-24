    using System;
    using System.Diagnostics;
    using System.ComponentModel;
    namespace MyProcessSample
    {
        class MyProcess
        {
            public static void Main()
            {
                Process myProcess = new Process();
                try
                {
                    myProcess.StartInfo.UseShellExecute = false;
                    myProcess.StartInfo.FileName = @"yourpath\youtube-dl.exe";
                    myProcess.StartInfo.CreateNoWindow = false;
                    myProcess.StartInfo.Arguments = "https://www.youtube.com/watch?v=KFqrp4KSxio";
                    myProcess.Start();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
