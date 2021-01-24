	bool portOpen;
	for (int portNo = 1; portNo < (fasttScan ? 1025 : 65537); portNo++)
	{
		TcpClient client = new TcpClient
		{
			SendTimeout = (fasttScan ? 2 : 10),
			ReceiveTimeout = (fasttScan ? 2 : 10)
		};
		var tcpClientASyncResult = client.BeginConnect(ipAddress, portNo, asyncResult =>
		{
			portOpen = false;
			try
			{
				client.EndConnect(asyncResult);
				portOpen = true;
			}
			catch (SocketException)
			{
			}
			catch (NullReferenceException)
			{
			}
			catch (ObjectDisposedException)
			{
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message); // ? unknown socket failure ?
			}
			if (portOpen)
				Console.WriteLine($"{ipAddress}:{portNo}:{portOpen}");
			client.Dispose();
			client = null;
		}, null);
		tcpClientASyncResult.AsyncWaitHandle.WaitOne();
	}
