     public static class Logger
     {
    	  public static void Log(LogLevel level, Func<string> delegateFunction) {
    			if (level >= CurrentLogLevel)
    			{
    				 var stringToLog = delegateFunction();
    				 Log(level, stringToLog); // Use normal Log functionality to log it
    			}
    	  }
     }
