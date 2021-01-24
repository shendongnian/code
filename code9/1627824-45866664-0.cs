    private bool _busy;
    private object locker = new object();
    
    private void StartBackgroundWork()
    {
    	lock (this.locker)
    	{
    		if (_busy)
    		{
    			return;
    		}
    		_busy = true;
    	}
    
    	Task.Factory.StartNew(() =>
    	{
    		try
    		{
    			// Do work
    		}
    		finally
    		{
    
    			lock (this.locker)
    				_busy = false;
    		}
    	}, TaskCreationOptions.LongRunning);
    }
