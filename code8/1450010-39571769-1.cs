	public void SetTimer()
	{	
        // this is System.Threading.Timer, ofcource
		_timer = new Timer(Tick, null, _interval, Timeout.Infinite);
	}
	
	private void Tick(object state)
	{
		try
		{
			// do your stuff
		}	
		finally
		{
			_timer?.Change(_interval, Timeout.Infinite);
		}
	}
	
	// dont forget to dispose your timer.
