    static class ProcessExec
    {
        public static string Start(string command)
        {
            Process process = new Process();
            process.StartInfo.FileName = "powershell.exe";
            process.StartInfo.Arguments = command;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
    
            process.Start();
    
            return process.StandardOutput.ReadToEnd();
        }
    }
