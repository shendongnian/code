    private async Task ConnectWebsocket() {
            websocket = new MessageWebSocket();
            Uri server = new Uri(WebSocketURI); //like ws://localhost:4300/socket.io/?EIO=3&transport=websocket
            websocket.Control.MessageType = SocketMessageType.Utf8;
            websocket.MessageReceived += Websocket_MessageReceived;
            websocket.Closed += Websocket_Closed;
            try {
                await websocket.ConnectAsync(server);
                isConnected = true;
                writer = new DataWriter(websocket.OutputStream);
            }
            catch ( Exception ex ) // For debugging
            {
                // Error happened during connect operation.
                websocket.Dispose();
                websocket = null;
                Debug.Log("[SocketIOComponent] " + ex.Message);
                
                if ( ex is COMException ) {
                    Debug.Log("Send Event to User To tell them we are unable to connect to Pi");
                }
                return;
            }
        }
