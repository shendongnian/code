    try
    {
        var received = await webSocketConnection.ReceiveAsync(...);
    }
    catch(WebSocketException webSocketException)
    {
        if(webSocketException.WebSocketErrorCode == WebSocketError.ConnectionClosedPrematurely)
        {
            //custom logic
        }
    }
