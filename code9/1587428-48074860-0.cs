    var webSocketClient = new ClientWebSocket();
    var cancellationToken = new CancellationToken();
    
    await webSocketClient.ConnectAsync(new Uri("wss://ws-feed.gdax.com"), cancellationToken).ConfigureAwait(false);
    if (webSocketClient.State == WebSocketState.Open)
    {
        var requestString = JsonConvert.SerializeObject(new {
            type = "subscribe",
            product_ids = new[]{"ETH-EUR"},
            channels = new[]{"ticker"}
        });
    
        var requestBytes = UTF8Encoding.UTF8.GetBytes(requestString);
        var subscribeRequest = new ArraySegment<byte>(requestBytes);
        var sendCancellationToken = new CancellationToken();
        await webSocketClient.SendAsync(subscribeRequest, WebSocketMessageType.Text, true, sendCancellationToken).ConfigureAwait(false);
    
        while (webSocketClient.State == WebSocketState.Open)
        {
            var receiveCancellationToken = new CancellationToken();
            using(var stream = new MemoryStream(1024))
            {
                var receiveBuffer = new ArraySegment<byte>(new byte[1024*8]);
                WebSocketReceiveResult webSocketReceiveResult;
                do
                {
                    webSocketReceiveResult = await webSocketClient.ReceiveAsync(receiveBuffer, receiveCancellationToken).ConfigureAwait(false);
                    await stream.WriteAsync(receiveBuffer.Array, receiveBuffer.Offset, receiveBuffer.Count);
                } while(!webSocketReceiveResult.EndOfMessage);
                
                var message = stream.ToArray().Where(b => b != 0).ToArray();
                messageReceived(Encoding.ASCII.GetString(message, 0, message.Length));
            }
        }
    }
