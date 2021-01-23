    Process[] arrProcess = Process.GetProcesses();
    
    foreach (Process process in arrProcess)
    {
        if (!string.IsNullOrEmpty(process.MainWindowTitle))
        {
        //Do something with your App
        }
        else
        {
        //Do something with your Background process
        }
    }
