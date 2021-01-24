    System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcesses();
    foreach(System.Diagnostics.Process p in processes)
    {
        if(p.MainWindowTitle == "Test Window")
        {
            twHandle = p.MainWindowHandle;
            break;
        }
    }
