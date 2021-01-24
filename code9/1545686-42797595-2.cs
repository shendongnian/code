    /// <summary>
    /// On WebSocket context.
    /// </summary>
    /// <param name="context"></param>
    private async void OnWebSocketContext(System.Net.WebSockets.HttpListenerWebSocketContext context)
    {    
         WebSocket webSocket = null;
         try
         {
             // Get the current web socket.
             webSocket = context.WebSocket;
             CancellationTokenSource receiveCancelToken = new CancellationTokenSource();
             byte[] receiveBuffer = new byte[READ_BUFFER_SIZE];
             // While the WebSocket connection remains open run a 
             // simple loop that receives data and sends it back.
             while (webSocket.State == WebSocketState.Open)
             {
                 // Receive the next set of data.
                 ArraySegment<byte> arrayBuffer = new ArraySegment<byte>(receiveBuffer);
                 WebSocketReceiveResult receiveResult = await webSocket.ReceiveAsync(arrayBuffer, receiveCancelToken.Token);
                 // If the connection has been closed.
                 if (receiveResult.MessageType == WebSocketMessageType.Close)
                 {
                      break;
                 }
                 else
                 {
                      // Start conversation.
                 }
            }
            // Cancel the receive request.
            if (webSocket.State != WebSocketState.Open)
                 receiveCancelToken.Cancel();
        }
        catch { }
        finally
        {
            // Clean up by disposing the WebSocket.
            if (webSocket != null)
                webSocket.Dispose();
        }
    }
