    // we need tokens to be able to cancel waiting
    var cts = new CancellationTokenSource();
    var ct = cts.Token;
    
    Task.Factory.StartNew(() =>
    {
    	bool completed = false;
    	while (!ct.IsCancellationRequested && !completed)
    	{
            // will check if our routine is cancelled each second
    		completed = 
    			WaitHandle.WaitAll(
    				events.Values.Cast<ManualResetEvent>().ToArray(),
    				TimeSpan.FromSeconds(1)); 
    	}
    
    	if (completed) // if not completed, then somebody cancelled our routine
    		; // change your variable here
    });
