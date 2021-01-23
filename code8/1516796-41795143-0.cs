	public Socket TryConnect(...)
	{
		Socket socket;
		try
		{
			socket = new Socket(...);
			var connect = Task.Factory.FromAsync(
				socket.BeginConnect, socket.EndConnect, host, port, null);
			var isConnected = connect.Wait(TimeSpan.FromSeconds(0.5));
			if (!isConnected)
			{
				socket.Close();
				return null;
			}
			
			return socket;		
		}
		catch
		{
			if (socket != null)
            {
                socket.Dispose();
            }
			throw;
		}
	}
	for (var i = 0; i < 10; i++)
	{
		var socket = TryConnect();
		if (socket != null)
			return socket;
	}
