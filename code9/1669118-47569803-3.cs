       private void HandleListener()
        {
            try
            {
                while (listener != null && listener.IsListening)
                {
                    HttpListenerContext listenerContext = await listener.GetContextAsync();
                    WebSocketContext webSocketContext = await listenerContext.AcceptWebSocketAsync(subProtocol: null);
                    WebSocket webSocket = webSocketContext.WebSocket;
                    clients.Add(webSocket);
                    HandleClient(webSocket);
                }
            }
            catch (HttpListenerException) { } // Got here probably because StopWSServer() was called
        }
