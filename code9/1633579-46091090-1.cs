    private CancellationTokenSource cts = new CancellationTokenSource();
    private CancellationToken token = new CancellationToken();
    private int running;
    
    btnLog.TouchUpInside += async (sender, e) =>
    {
    	if (Interlocked.CompareExchange(ref running, 1, 0) == 0)
    	{
    		try
    		{
    			Task.Run(async () =>
    			{
    				if (!token.IsCancellationRequested)
    				{
    					await doWork();
    					running = 0;
    					return;
    				}
    				running = 0;
    			}, token);
    		}
    		catch (TaskCanceledException tcEx)
    		{
    			running = 0;
    		}
    	}
    };
    
    private Task doWork()
    {
    	//Async method
    }
