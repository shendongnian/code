    public void tcpTest2(IPAddress server, Int32 port, int x)
            {
                TcpClient client;
                
                sendData("Connecting to Host: " + server + " on port: " + port.ToString() + "...");
                sendStatus("Connecting", x);
                                      
                try
                {
                    client = new TcpClient(server.ToString(), port); 
                    
                    if (false)
                    {
                        
                    }               
    
                    if (true)
                    {
                        sendData("Connection to Host: " + server + " on port: " + port.ToString() + "..ESTABLISHED");
                        sendStatus("Connected", x);        
                        receiveData(client, server, port);
                    }
                    
                }
                catch (Exception)
                {
                    sendData("Connection to Host: " + server + " on port: " + port.ToString() + "..FAILED");
                    sendStatus("Failed", x);
                }
            }
    
            public void receiveData(TcpClient client, IPAddress server, int port)
            {
                Byte[] data = System.Text.Encoding.Default.GetBytes("|");
                data = new byte[1024];
                string stringData;
                bool connected;
                connected = true;
    
                while (connected == true)
                {
                    string fromC = client.Client.RemoteEndPoint.ToString();
                    NetworkStream ns = client.GetStream();
                    int recv = ns.Read(data, 0, data.Length);
                    stringData = Encoding.ASCII.GetString(data, 0, recv);
                    sendUpdate("{" + fromC + "}" + stringData);
                    connected = IsConnected(client);
                }
    
                if (connected == false)
                {
                    sendData("Connection to Host: " + server + " on port: " + port.ToString() + "..LOST");
                    sendLost(server);
                }
            }
    
            public bool IsConnected(TcpClient client)
            {
                try
                {
                    if (client != null && client.Client != null && client.Client.Connected)
                    {
                        if (client.Client.Poll(0, SelectMode.SelectRead))
                        {
                            byte[] buff = new byte[1];
                            if (client.Client.Receive(buff, SocketFlags.Peek) == 0)
                            {
                                return false;
                            }
                            else
                            {
                                return true;
                            }
                        }
    
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
            }
        }       
