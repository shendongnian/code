    #region server
    Socket serverSocket;
    bool serverIsAlive;
    SemaphoreSlim waitForConnection = new SemaphoreSlim(0);
    private Encoding encod = Encoding.Unicode;
    public void ServerStartInThread()
    {
        byte[] bytes = new Byte[1024];
        IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
        IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 5500);
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        serverSocket = socket;
        try
        {
            socket.Bind(localEndPoint);
            socket.Listen(100);
            Thread pollThread = new Thread(delegate () {
                serverIsAlive = true;    // needs if reopen
                SendMessage("Server Started");
                while (serverIsAlive)
                {
                    try
                    {
                        SendMessage("Server is waiting for a connection...");
                        socket.BeginAccept(new AsyncCallback(ServerOnClientConnection), socket);
                        waitForConnection.Wait();
                    }
                    catch (Exception ex)
                    {
                        SendMessage("Server: " + ex.ToString());
                    }
                }
                SendMessage("Server Stopped");
                socket.Close();
            })
            {
                Name = "SocketServer"
            };
            pollThread.Start();
        }
        catch (Exception ex)
        {
            SendMessage("Server: " + ex.ToString());
        }
    }
    public void ServerOnClientConnection(IAsyncResult ar)
    {
        try
        {
            Socket listener = (Socket)ar.AsyncState;
            Socket clientSocket = listener.EndAccept(ar);
            SendMessage("ServerOnClientConnection Client: " + clientSocket.RemoteEndPoint.ToString());
            StateObject state = new StateObject()
            {
                socket = clientSocket
            };
            clientSocket.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ServerReceiveCallback), state);
            waitForConnection.Release();
        }
        catch (Exception ex)
        {
            SendMessage("ServerOnClientConnection: " + ex.ToString());
        }
    }
