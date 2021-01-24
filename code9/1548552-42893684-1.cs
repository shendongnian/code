    Process[] processes = Process.GetProcesses();
    foreach(var thisProcess in processes)
    {
       Icon ico = Icon.ExtractAssociatedIcon(thisProcess.MainModule.FileName);
    }
