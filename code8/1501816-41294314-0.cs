    public static void Do<T>(
    	Action<T> action,
    	T param,
    	int retryCount = 3)
    {
    	var exceptions = new List<Exception>();
    
    	for (int retry = 0; retry < retryCount; retry++)
    	{
    		try
    		{
    			action(param);
    			return;
    		}
    		catch (Exception ex)
    		{
    			exceptions.Add(ex);
    		}
    	}
    
    	throw new AggregateException(exceptions);
    }
