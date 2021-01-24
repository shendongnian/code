	public void StartListening(Connection connection)
	{
		// There are codes here..
		try
		{
			listener.Bind(localEndPoint);
			listener.Listen(2);
			var handles = new EventWaitHandle[] 
			{ 
				allDone, 
				connection.CancellationTokenSource.Token.WaitHandle 
            };
	
			do
			{                
				allDone.Reset();                    
				listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);
			}
			while(EventWaitHandle.WaitAny(handles) == 0);
			listener.Close();
		}
		catch (Exception e)
		{
			// There are codes here..
		}
		// There are codes here..
	}
