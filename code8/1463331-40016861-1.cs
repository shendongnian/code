    static void Main(string[] args)
    {
    	ExceptionHandler.InitiateDatabaseCall(() => CallDb("Dummy"));
	    ExceptionHandler.InitiateDatabaseCall<int>(() => { throw new InvalidOperationException(); });
    }
    int CallDb(string justToShowExampleWithParameters)
    {
	    return 5;	
    }
    public static class ExceptionHandler
    {
	    public static T InitiateDatabaseCall<T>(Func<T> method)
    	{
	    	try
		    {
			    return method.Invoke();
    		}
    		catch (Exception e)
    		{
    			// do logging
	    		Console.WriteLine(e.Message);
		    	return default(T);
		    }
    	}
    }
