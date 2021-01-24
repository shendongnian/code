    Process currentProcess = Process.GetCurrentProcess();
    bool suocide = false;
    foreach (Process process in Process.GetProcessesByName(currentProcess.ProcessName))
    {
        if (process.MainModule.FileName == currentProcess.MainModule.FileName && process.Id != currentProcess.Id)
        {
            process.CloseMainWindow();
            process.Close();
            //process.Kill(); or you can do kill instead
            suocide = true;
        }
    }
    if (suocide)
        currentProcess.Kill(); // you probably don't care about new process as it is just for closing purpose but if you do then do a proper application exit
