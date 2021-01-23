    private class LogMessage
    {
      string module { get; set; }
      string message { get; set; } 
      DateTime LoggedOn { get;set;}
    }
    private List<LogMessage> messages = new List<LogMessage>();
    private static void Log(string message, string type, string module)  
    {
        /* remove any messages older than X time */
        if(messages.Where(x => x.module == module && x.message == message).Any())
        {
           // You can add more properties to the where for comparison
           // Already exist so return
           return;
        }
        
        messages.Add(new LogMessage() { module = module, message = message, LoggedOn = DateTime.Now});
        try
        {
           sLogMessage = string.Format("Computer: {0}, User: {1}, Module: {2}, Method: {3}, [{4}] {5}{6}",
                                            System.Environment.MachineName, System.Environment.UserName,
                                            module, new StackTrace().GetFrame(2).GetMethod().Name,
                                            type, message, Environment.NewLine);
        }
        catch (Exception)
        {
        }
    
        switch (type)
        {
           case "DEBUG": logger.Debug(sLogMessage);
                break;
           case "INFO":
                try
                {
                    logger.Info(sLogMessage);
                }
                catch (Exception)
                {
                }
                break;
            case "WARNING": logger.Warn(sLogMessage);
                break;
            //here displays my error message and i want to check if it already exixts
            case "ERROR": logger.Error(sLogMessage);
                break;
        }
    }
