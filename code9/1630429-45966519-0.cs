    public async Task<IObservable<string>> ConnectAsync(Uri uri)
    {
        webSocket = new MessageWebSocket();
        webSocket.Control.MessageType = SocketMessageType.Utf8;
        var toReturn = Observable
            .FromEventPattern<MessageWebSocketMessageReceivedEventArgs>(webSocket, nameof(webSocket.MessageReceived))
            .Select(ReadString)
            .Subscribe(subject);
        await webSocket.ConnectAsync(uri);
        return toReturn;
    }
