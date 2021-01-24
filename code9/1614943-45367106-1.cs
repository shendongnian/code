    using System;
    
    public static void Run(TimerInfo myTimer, TraceWriter log)
    {
        System.Diagnostics.Process process = new System.Diagnostics.Process();
        process.StartInfo.FileName = @"D:\home\site\wwwroot\TimerTriggerCSharp1\testfunc.exe";
        process.StartInfo.Arguments = "";
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardError = true;
        process.Start();
        string output = process.StandardOutput.ReadToEnd();
        string err = process.StandardError.ReadToEnd();
        process.WaitForExit();
        
        log.Info($"C# Timer trigger function executed at: {DateTime.Now}");
    }
