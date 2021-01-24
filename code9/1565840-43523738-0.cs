        public void Start()
        {
            ServerStarted = true;
            if (this.authHandler == null)
                this.authHandler = new DefaultAuthHandler();
            if (this.fsHandler == null)
                this.fsHandler = new DefaultFileSystemHandler();
            socketServer = new Socket(AddressFamily.InterNetwork,
                                      SocketType.Stream, 
                                      ProtocolType.Tcp);
            /* Here is the change. In this way I can reuse multiple times the
             * same address without getting the SocketException.*/
            socketServer.SetSocketOption(SocketOptionLevel.Socket,
                                         SocketOptionName.ReuseAddress, 
                                         1);
            Socket handler = null;
            try
            {
                socketServer.Bind(endpoint);
                socketServer.Listen(10);
                while (ServerStarted)
                {
                   handler = socketServer.Accept();
                    try
                    {
                        IPEndPoint socketPort = (IPEndPoint)handler.RemoteEndPoint;
                        Session session = new Session(handler,bufferSize, 
                                             this.authHandler.Clone(socketPort),
                                             this.fsHandler.Clone(socketPort));
                        session.Start();
                        sessions.Add(session);
                        p_HostIPAddress = socketPort.Address;
                        if (p_HostIPAddress != null)
                            HostConnected = true;
                        // Purge old sessions
                        for (int i = sessions.Count - 1; i >= 0; --i)
                        {
                            if (!sessions[i].IsOpen)
                            {
                                sessions.RemoveAt(i);
                                --i;
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                    }
                }
            }
            catch (SocketException socketEx)
            {
            }
            finally
            {
                handler.Close();
                foreach (Session s in sessions)
                {
                    s.Stop();
                    HostConnected = false;
                }
            }
        }
