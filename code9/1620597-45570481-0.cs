    private async Task Receive(WebSocket socket, Action<WebSocketReceiveResult, byte[]> handle) //original 
    {   
        while(socket.State == WebSocketState.Open)
        {
            var buffer = new ArraySegment<byte>(new byte[1024]);
            var result = await socket.ReceiveAsync
            (
                buffer: buffer,
                cancellationToken: CancellationToken.None
            );
    		
    		var resized = new byte[buffer.Count];
    		Array.Copy(buffer.Array, buffer.Offset, resized, 0, buffer.Count);
            handle(result, resized);
        }
    }
