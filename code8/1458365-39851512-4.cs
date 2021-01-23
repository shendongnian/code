        Process[] runningProcesses = Process.GetProcesses();
        var sessionId = Process.GetCurrentProcess().SessionId;
        var currentSessionProcesses = runningProcesses.Where(c => c.SessionId == sessionId).ToList();
        foreach (var process in currentSessionProcesses)
        {
            Console.WriteLine($"Process: {process.ProcessName} ID: {process.Id} Path: {process.MainModule.FileName}");
        }
