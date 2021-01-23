    using System;
    using System.Diagnostics;
    
    public static void Run(string input, TraceWriter log)
    {
        log.Info("Executing");
        using (var process = new Process())
        {
            process.StartInfo.FileName = @"D:\Program Files (x86)\Git\usr\bin\dir.exe";
            process.StartInfo.Arguments = @"D:\home";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            log.Info(output);
        }
    }
