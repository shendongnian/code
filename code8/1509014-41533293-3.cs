    const int MaxAllowTimeInMs = 250;
    void Main()
    {
	    var timer = new  DispatcherTimer();
	    timer.Interval = TimeSpan.FromMilliseconds(MaxAllowTimeInMs);
	    timer.Tick += async (s, e) =>
	    {
	    	using(var cts = new CancellationTokenSource())
	    	{
	    		try
	    		{
	    			cts.CancelAfter(MaxAllowTimeInMs);
	    			await MyTask(cts.Token);
	    		}
	    		catch (OperationCanceledException)
	    		{
	    			// MyTask took longer than 205ms
	    		}
	    	}
    	};
	    timer.Start();
    }
    async Task MyTask(CancellationToken ct)
    {
	    // Simulate some work
        ...
	    ct.ThrowIfCancellationRequested();
    }
