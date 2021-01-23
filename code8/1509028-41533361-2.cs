    static void WriteData(NetworkStream stream, String message)
    {
    	try
    	{
    		// Translate the passed message into ASCII and store it as a Byte array.
    		Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
    
    		// Send the message to the connected TcpServer.
    
    		stream.Write(data, 0, data.Length);
    
    		Console.WriteLine("Sent: {0}", message);
    
    		// Receive the TcpServer.response.
    
    		// Buffer to store the response bytes.
    		data = new Byte[256];
    
    		// String to store the response ASCII representation.
    		String responseData = String.Empty;
    
    		// Read the first batch of the TcpServer response bytes.
    
    		Int32 bytes = stream.Read(data, 0, data.Length);
    		responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
    
    		Console.WriteLine("Received: {0}", responseData);
    	}
    	catch (ArgumentNullException e)
    	{
    		Console.WriteLine("ArgumentNullException: {0}", e);
    	}
    	catch (SocketException e)
    	{
    		Console.WriteLine("SocketException: {0}", e);
    	}
    }
    
    static void ClientCode()
    {
    	int[] data = new int[4];
    	data[0] = 1;
    	data[0] = 1;
    	data[0] = 1;
    	data[0] = 1;
    
    	// Create a TcpClient.
    	// Note, for this client to work you need to have a TcpServer 
    	// connected to the same address as specified by the server, port
    	// combination.
    	Int32 port = 85;
    	TcpClient client = new TcpClient(server, port);
    	client.NoDelay = true;
    
    	// Get a client stream for reading and writing.
    	NetworkStream stream = client.GetStream();
    
    	for (int i = 0; i < data.Length; i++)
    	{
    		WriteData(stream, data[i].ToString());
    	}
    
    	// Close everything.
    	stream.Close();
    	client.Close();
    }
