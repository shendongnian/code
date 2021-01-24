    /// <summary>
    /// Starts a new process on the local machine. Returns the PID of the started process
    /// </summary>
    /// <param name="processName"></param>
    /// <param name="arguments"></param>
    private int StartProcess(string processName, string arguments)
    {
        // Initializes the process
        Process process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = processName,
                Arguments = arguments,
                UseShellExecute = false,
                CreateNoWindow = true
            }
        };
        // Starts the process
        process.Start();
        return process.Id;
    }
    /// <summary>
    /// Kills the process that equals the passed PID
    /// </summary>
    /// <param name="pid"></param>
    private void KillProcess(int pid)
    {
        Process process = Process.GetProcessById(pid);
        process.Kill();
    }
