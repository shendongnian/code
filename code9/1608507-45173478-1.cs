    var myLogger = LogManager.GetCurrentClassLogger();
    var eventInfo = new LogEventInfo(LogLevel.Info, MyLogger.Name, "Message");
    eventInfo.Properties["CustomValue"] = "My custom string";
    eventInfo.Properties["CustomDateTimeValue"] = new DateTime(2020, 10, 30, 11, 26, 50);
    eventInfo.Properties.Add("CustomNumber", 42);
    logger.Log(eventInfo);
    
    _myTarget.IncludeAllProperties=True;
