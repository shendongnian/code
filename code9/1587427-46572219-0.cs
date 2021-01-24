	ClientWebSocket socket = new ClientWebSocket();
	Task task = socket.ConnectAsync(new Uri("wss://ws-feed.gdax.com"), CancellationToken.None);
	task.Wait();
	Thread readThread = new Thread(
		delegate(object obj)
		{
			byte[] recBytes = new byte[1024];
			while (true) {
				ArraySegment<byte> t = new ArraySegment<byte>(recBytes);
				Task<WebSocketReceiveResult> receiveAsync = socket.ReceiveAsync(t, CancellationToken.None);
				receiveAsync.Wait();
				string jsonString = Encoding.UTF8.GetString(recBytes);
				Console.Out.WriteLine("jsonString = {0}", jsonString);
				recBytes = new byte[1024];
			}
			
		});
	readThread.Start();
	string json = "{\"product_ids\":[\"btc-usd\"],\"type\":\"subscribe\"}";
	byte[] bytes = Encoding.UTF8.GetBytes(json);
	ArraySegment<byte> subscriptionMessageBuffer = new ArraySegment<byte>(bytes);
	socket.SendAsync(subscriptionMessageBuffer, WebSocketMessageType.Text, true, CancellationToken.None);
	Console.ReadLine();
