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
                    Task.Factory.StartNew(()=>  HandleClient(webSocket), TaskCreationOptions.LongRunning);
                }
            }
            catch (HttpListenerException) { } // Got here probably because StopWSServer() was called
        }
