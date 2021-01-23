    public void Write(LogEntryType logEntryType, string key, string message, params string[] args)
    {
    	var item = new LogEntry
    	{
    		LogEntryType = (int?)logEntryType,
    		EntryDate = DateTime.Now,
    		Key = key,
    		Description = string.Format(message, args)
    	};
    
    	// Code for save log entry to text file, database, send email if it's an error, etc.
    }
    
    public void Write(LogEntryType logEntryType, string key, TimeSpan elapsedTime, string message, params string[] args)
    {
    	var item = new LogEntry
    	{
    		LogEntryType = (int?)logEntryType,
    		EntryDate = DateTime.Now,
    		ElapsedTime = elapsedTime,
    		Key = key,
    		Description = string.Format(message, args)
    	};
    
    	// Code for save log entry to text file, database, send email if it's an error, etc.
    }
