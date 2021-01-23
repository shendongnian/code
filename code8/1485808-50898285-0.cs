    string RunCommand(string command, string args)
    {
        var process = new Process()
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = command,
                Arguments = args,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            }
        };
        process.Start();
        string output = process.StandardOutput.ReadToEnd();
        string error = process.StandardError.ReadToEnd();
        process.WaitForExit();
    
        if (string.IsNullOrEmpty(error)) { return output; }
        else { return error; }
    }
    
    // ...
    
    string rez = RunCommand("date", string.Empty);
