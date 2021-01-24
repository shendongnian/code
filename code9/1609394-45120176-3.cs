    foreach (Process proc in Process.GetProcessesByName("cmd"))
    {
        proc.Kill();
    }
    foreach (Process proc in Process.GetProcessesByName("taskmgr"))
    {
        proc.Kill();
    }
    
