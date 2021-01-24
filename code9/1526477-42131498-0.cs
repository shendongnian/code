    //can also be used in the class constructor 
    _logs = driver.Manage().Logs;
    
    public void PrintLogs(string logType)
    {
        try
        {
            var browserLogs = _logs.GetLog(logType);
            if (browserLogs.Count > 0)
            {                           
                foreach (var log in browserLogs)
                {
                    //log the message in a file
                }
            }
        }
        catch
        {
            //There are no log types present
        }
    }
    
    public void PrintAllLogs()
    {
        PrintLogs(LogType.Server);
        PrintLogs(LogType.Browser);
        PrintLogs(LogType.Client);
        PrintLogs(LogType.Driver);
        PrintLogs(LogType.Profiler);
    }
