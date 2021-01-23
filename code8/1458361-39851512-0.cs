        Process[] processMame = Process.GetProcessesByName("yourProcess");
        if (processMame.Length > 0)
        {
            /// You got your process here
            /// Do whatever you want 
        }
        Process[] processlist = Process.GetProcesses();
        foreach (Process process in processlist)
        {
            Console.WriteLine($"Process: {process.ProcessName} ID: {process.Id}");
        }
