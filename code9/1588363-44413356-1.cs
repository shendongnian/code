    bool IsFoxitProcessRunning = false;
    foreach(Process p in Processlist)
    {
        if(p.ProcessName == "Foxit process name here") //Replace with the name of the foxit process
        {
            IsFoxitProcessRunning  = true;
        }
    }
