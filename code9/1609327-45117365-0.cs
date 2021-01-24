    // TCP Server C#, look at [msdn][1]
	try
	{
	  // Set the TcpListener on port 8080 of Any IP Address.
	  TcpListener server = new TcpListener(IPAddress.Any, 8080);
	  // Start listening for client requests.
	  server.Start();
	  // Buffer for reading data
	  Byte[] bytes = new Byte[1024];
	  String data = null;
	  // Enter the listening loop.
	  while(true) {
		Console.Write("Waiting for a connection... ");
		// Perform a blocking call to accept requests.
		// You could also user server.AcceptSocket() here.
		TcpClient client = server.AcceptTcpClient(); 
           
		Console.WriteLine("Connected!");
		// Get a stream object for reading and writing
		data = null;
		NetworkStream stream = client.GetStream();
		int i;
		// Loop to receive all the data sent by the client.
		while((i = stream.Read(bytes, 0, bytes.Length))!=0) 
		{   
		  // Translate data bytes to a ASCII string.
		  data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
		  Console.WriteLine("Received: {0}", data);
		  // Process the data sent by the client.
		  data = data.ToUpper();
		  byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);
		  // Send back a response.
		  stream.Write(msg, 0, msg.Length);
		  Console.WriteLine("Sent: {0}", data);            
		}
    }
