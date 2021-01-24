    class RetryWrapper
    {
    	readonly int n;
    
    	private RetryWrapper(int n)
    	{
    		this.n = n;
    	}
    
    	public static RetryWrapper Create(int n)
    	{
    		return new RetryWrapper(n);
    	}
    
    	public T TryNTimes<T>(Func<T> f)
    	{
    		var i = 0;
    		while (true)
    		{
    			try
    			{
    				return f();
    			}
    			catch
    			{
    				if (++i == n)
    				{
    					throw;
    				}
    			}
    		}
    	}
    }
