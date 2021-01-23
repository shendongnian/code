    private void Websocket_MessageReceived(MessageWebSocket sender, MessageWebSocketMessageReceivedEventArgs args) {
            try {
                using ( DataReader reader = args.GetDataReader() ) {
                    reader.UnicodeEncoding = UnicodeEncoding.Utf8;
                    try {
                        string read = reader.ReadString(reader.UnconsumedBufferLength);
                        //read = Regex.Unescape(read);
                        SocketData socc = SocketData.ParseFromString(read);
                        if (socc != null ) {
                            Debug.Log(socc.ToString());
                            SocketIOEvent e = new SocketIOEvent(socc.channel, new JSONObject( socc.jsonPayload));
                            lock ( eventQueueLock ) { eventQueue.Enqueue(e); }
                        }
                    }
                    catch ( Exception ex ) {
                        Debug.Log(ex.Message);
                    }
                }
            } catch (Exception ex ) {
                Debug.Log(ex.Message);
            }
        
        }
