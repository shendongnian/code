    public string RunGitCommand(string command, string args, string workingDirectory)
    {
        string git = "git";
        var results = "";
        var proc = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = git,
                Arguments = $"{command} {args}",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true,
                WorkingDirectory = workingDirectory,
            }
        };
            proc.Start();
            while (!proc.StandardOutput.EndOfStream)
            {
                results += $"{proc.StandardOutput.ReadLine()},";
            }
            proc.WaitForExit();
            return results;    
     }
