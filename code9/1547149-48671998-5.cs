    private const int BufferSize = 1024;
    private byte[] buffer = new byte[BufferSize];
    private IoTHubConnection ioTHubConnection;
    private NetworkStream stream;
    
    private async Task Start()
    {
    	listener = new TcpListener(IPAddress.Any, port);
    	listener.Start();
    
    	var client = await listener.AcceptTcpClientAsync();
    	ioTHubConnection = new IoTHubConnection("IoTHubName", deviceClientFactory, OnIoTHubMessage);
    	stream = client.GetStream();
    
    	// Read DeviceId and DeviceKey from some sort of StartConnection-message send by the TcpClient.
    	await ioTHubConnection.OpenAsync("DeviceId", "DeviceKey");
    
    	stream.BeginRead(buffer, 0, BufferSize, ReadTcpStreamCallback, null);
    }
    
    private void ReadTcpStreamCallback(IAsyncResult ar)
    {
    	var bytesRead = stream.EndRead(ar);
    
    	if (bytesRead > 0)
    	{
    		var message = System.Text.Encoding.ASCII.GetString(result);
    
    		ioTHubConnection.SendMessage(message);
    		
    		// Read again.
    		stream.BeginRead(buffer, 0, BufferSize, ReadTcpStreamCallback, null);
    	}
    }
    
    private async Task OnIoTHubMessage(string message)
    {
    	// Potentially do some translation on the IoTHub message
    	// and send it to the Device
		var byteData = Encoding.UTF8.GetBytes(message);
        stream.BeginWrite(byteData, 0, byteData.Length, SendTcpCallback, null);
    }
	
	private void SendTcpCallback(IAsyncResult ar)
	{
	    stream.EndWrite(ar);
	}
