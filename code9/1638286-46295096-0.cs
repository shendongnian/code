    WebSocket websocket = new WebSocket(url);
	websocket.Opened += (sender, e) =>
	{
		// successfully connected, do sth (this is what i need)
	};
	websocket.Error += (sender, e) =>
	{
		Console.WriteLine(e.Exception.Message);
	};
	websocket.MessageReceived += (sender, e) =>
	{
		string msg = e.Message;
	};
	websocket.Open();
