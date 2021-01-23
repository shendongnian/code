    EventLog myLog = new EventLog(); 
    myLog.Log = "Application";
    myLog.Source = "Application Error";
    
    var lastEntry = myLog.Entries[myLog.Entries.Count-1];
    var last_error_Message = lastEntry.Message;
    for(int index=myLog.Entries.Count-1; index>0;index--)
    {
    	var errLastEntry = myLog.Entries[index];
    	if (errLastEntry.EntryType == EventLogEntryType.Error)
    	{
    		//this is the last entry with Error
    		var appName = errLastEntry.Source;
    		break;
    	}
    }
