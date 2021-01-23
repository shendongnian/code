    private string ReadProcessOutput(string fileName, TimeSpan waitTime, string args, string commandToEnter) // Command to enter in input window.
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
                RedirectStandardInput = true,
                CreateNoWindow = true
            }
        };
        proc.Start();
        proc.StandardInput.WriteLine(commandToEnter);
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
