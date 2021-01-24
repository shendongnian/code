	var subscription =
		source
			.TakeWhile(data => webSocket.State == WebSocketState.Open)
			.SelectMany(data =>
				Observable.FromAsync(() =>
					webSocket.SendAsync(data.ToString(), WebSocketMessageType.Text, true, CancellationToken.None)))
			.Catch<WebSocketException>(ex =>
				Observable.FromAsync(() =>
					webSocket.CloseAsync(WebSocketCloseStatus.Empty, String.Empty, CancellationToken.None)))
			.Subscribe();
