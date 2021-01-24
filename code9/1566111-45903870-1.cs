        private List<Socket> _clients = new List<Socket>();
        private Thread _dataReceiveThread;
        private bool _isConnected;
        private void DataReceive()
        {
            while (_isConnected)
            {
                List<Socket> clients = new List<Socket>(_clients);
                foreach (Socket client in clients)
                {
                    try
                    {
                        if (!client.Connected) continue;
                        string txt = "";
                        while (client.Available > 0)
                        {
                            byte[] bytes = new byte[client.ReceiveBufferSize];
                            int byteRec = client.Receive(bytes);
                            if (byteRec > 0)
                                txt += Encoding.UTF8.GetString(bytes, 0, byteRec);
                        }
                        if (!string.IsNullOrEmpty(txt))
                            /* TODO: access the text received with "txt" */
                    }
                    catch (Exception e)
                    {
                        Exception_Handler(e);
                    }
                }
            }
        }
