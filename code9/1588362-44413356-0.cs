    bool IsFoxitProcessRunning = false;
    foreach(Process theprocess in processlist)
    {
        if(theprocess.ProcessName == "Foxit process name here") //Replace with the name of the foxit process
        {
            IsFoxitProcessRunning  = true;
        }
    }
