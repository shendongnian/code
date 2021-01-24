    public CncOnlinePageViewModel()
    {
        cnconline = new CncOnline();
        var t = cnconline.RefreshServerKanesWrathDataAsync();
        t.ContinueWith(OnCompleted);
    }
    
    private void OnCompleted(Task<string> task)
    {
    	if (task.IsFaulted)
    	{
    		// Check error
    		var exception = task.Exception;
    	}
    	else if (task.IsCanceled)
    	{
    		// User hit cancel?
    	}
    	else
    	{
    		// All good!
    		var result = task.Result;
    	}
    }
