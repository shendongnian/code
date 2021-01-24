	using (var pipeServer = new NamedPipeServerStream("MyServerPipe", PipeDirection.InOut))
	{
		Console.WriteLine("NamedPipeServerStream object created.");
		// Wait for a client to connect
		Console.Write("Waiting for client connection...");
		pipeServer.WaitForConnection();
		Console.WriteLine("Client connected.");
		try
		{
			using (var bw = new BinaryWriter(pipeServer))
			{
				var data = Encoding.ASCII.GetBytes("SendInformation data1 data2 data3");
				//var data = Encoding.ASCII.GetBytes("Start\r\n");
				bw.Write(data);
			}
		}
		// Catch the IOException that is raised if the pipe is broken
		// or disconnected.
		catch (IOException e)
		{
			Console.WriteLine("ERROR: {0}", e.Message);
		}
	}
