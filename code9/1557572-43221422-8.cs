    public CncOnlinePageViewModel()
    {
        cnconline = new CncOnline();
        var t = cnconline.RefreshServerKanesWrathDataAsync(); // assuming returns Task
        t.ContinueWith(OnCompleted);
    }
    
    private void OnCompleted(Task task)
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
    	}
    }
