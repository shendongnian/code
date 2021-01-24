	public IObservable<string> Connect(Uri uri)
	{
		return
			Observable
				.Using(
					() =>
					{
						var webSocket = new MessageWebSocket();
						webSocket.Control.MessageType = SocketMessageType.Utf8;
						return webSocket;
					},
					webSocket =>
						Observable
							.FromAsync(() => webSocket.ConnectAsync(uri))
							.SelectMany(u =>
								Observable
									.FromEventPattern<MessageWebSocketMessageReceivedEventArgs>(webSocket, nameof(webSocket.MessageReceived))
									.SelectMany(pattern =>
										Observable
											.Using(
												() =>
												{
													var reader = pattern.EventArgs.GetDataReader();
													reader.UnicodeEncoding = UnicodeEncoding.UTF8;
													return reader;
												},
												reader => Observable.Return(reader.ReadString(reader.UnconsumedBufferLength))))));
	}
