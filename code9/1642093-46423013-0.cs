    public void Run(string cmd)
        {
            Process process = new Process();
            process.StartInfo.FileName = FileName;
            process.StartInfo.Arguments = cmd;
            process.StartInfo.UseShellExecute = UseShellExecute;
            process.StartInfo.RedirectStandardOutput = RedirectStandardOutput;
            process.StartInfo.CreateNoWindow = CreateNoWindow;
            process.Start();
        }
