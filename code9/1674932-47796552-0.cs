    static private void AddConsoleAppender()
    {
        // ...
    	var l = (log4net.Repository.Hierarchy.Logger)logger.Logger;
        // ...
    	l.Repository.Configured = true;
    }
