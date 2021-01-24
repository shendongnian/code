     public void tcpConnect(object pos)
            {
                IPAddress hostIP = IPAddress.Parse(pos.ToString().Split(':')[0]);
                int hostPort = Int32.Parse(pos.ToString().Split(':')[1]);
                rowInd = Int32.Parse(pos.ToString().Split(':')[2]);
    
                var client = new TcpClient();            
    
                if (!client.ConnectAsync(hostIP, hostPort).Wait(1000))
                {
                    sendData("Connection to Host: " + hostIP + " on port: " + hostPort.ToString() + ".FAILED");
                    sendStatus("Failed", "", rowInd);
                    return;
                }
    
                if (true)
                {
                    sendData("Connection to Host: " + hostIP.ToString() + " on port: " + hostPort.ToString() + "..ESTABLISHED");
                    Thread thread = new Thread(new ParameterizedThreadStart(ClientHandler));
                    thread.IsBackground = true;
                    Thread.FreeNamedDataSlot(hostIP.ToString() + rowInd.ToString());
                    thread.Name = hostIP.ToString() + rowInd.ToString();
                    thread.Start(client);
                    threadID = thread.ManagedThreadId.ToString();
                    sendStatus("Connected", threadID, rowInd);
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
              
            public void ClientHandler(object c)
            {            
                TcpClient client = (TcpClient)c;            
                NetworkStream netstream = client.GetStream();
                string fromC = client.Client.RemoteEndPoint.ToString();
                string fromIP = fromC.Split(':')[0];
    
                bool connected = true;
                while (connected)
                {
                    Thread.Sleep(10);
                    try
                    {
                        byte[] data = new byte[client.ReceiveBufferSize];
                        data = System.Text.Encoding.Default.GetBytes("|");
                        data = new byte[1024];
                        string stringData;                   
                        NetworkStream ns = client.GetStream();
                        int recv = ns.Read(data, 0, data.Length);
                        stringData = Encoding.ASCII.GetString(data, 0, recv);
                        sendUpdate("|" + fromC + "|" + stringData);
                        connected = IsConnected(client);
                    }
                    catch (Exception err)
                    {   
                        connected = false;
                        sendLost(fromIP);
    
                        using (StreamWriter w = File.AppendText("Arch-PTO.log"))
                        {
                            Log("tcpServices.ClientHandler: " + err.Message, w);
                        }
                    }
                }            
                sendLost(fromIP);
            }
