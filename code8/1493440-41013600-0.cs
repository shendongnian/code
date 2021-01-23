    private string ReadProcessOutput(string fileName, TimeSpan waitTime, string args)
    {
        Console.WriteLine("Starting process: {0}", fileName);
        Process proc = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = fileName,
                Arguments = args,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            }
        };
        proc.Start();
        proc.WaitForExit((int)waitTime.TotalMilliseconds);
        
        if (proc.HasExited)
        {
            Console.WriteLine("Process {0} exited with code {1}", fileName, proc.ExitCode);
            string output = proc.StandardOutput.ReadToEnd();
            Console.WriteLine("Process output: " + Environment.NewLine + output);
            return output;
        }
        return null;
    }
