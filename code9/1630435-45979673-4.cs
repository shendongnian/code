	public IObservable<string> ConnectAsync(Uri uri)
	{
		return
			Observable
				.Create<string>(async o =>
				{
				    var webSocket = new MessageWebSocket();
				
				    webSocket.Control.MessageType = SocketMessageType.Utf8;
				
				    var subscription = Observable
				        .FromEventPattern<MessageWebSocketMessageReceivedEventArgs>(webSocket, nameof(webSocket.MessageReceived))
				        .Select(ReadString)
				        .Subscribe(o);
				
				    await webSocket.ConnectAsync(uri);
					
				    return subscription;
				});
	}
