    public class TCPServer : ITCPServer
    {
        private readonly IPEndPoint _ipEndPoint;
        private TcpListener _tcpListener;
        private TcpClient _tcpClient;
        private bool _runServer;
        private bool _connectToClient;
        private NetworkStream _networkStream;
        private volatile bool _isRunning;
        public TCPServer(IPEndPoint ipEndpoint)
        {
            _ipEndPoint = ipEndpoint;
        }
        #region Properties
        public bool IsRunning
        {
            get { return _isRunning; }
        }
        #endregion
        #region Events
        public event Action<byte[]> OnMessageReceived;
        public event Action<string> OnConnectionOpened;
        public event Action<string> OnConnectionClosed;
        public event Action<LogLevel, string> OnLogMessage;
        #endregion
        #region Public Methods
        public void Start()
        {
            _tcpListener = new TcpListener(_ipEndPoint);
            _runServer = true;
            _tcpListener.Start();
            var thread = new Thread(RunServerEngine);
            thread.Name = "TcpServer";
            thread.Start();
            while (!_isRunning)
            {
            }
            var localEndpoint = (IPEndPoint)_tcpListener.LocalEndpoint;
            RaiseOnLogMessage(LogLevel.Info, String.Format("Server started listening at ip address {0} on port {1}", localEndpoint.Address, localEndpoint.Port));
        }
        public void Stop()
        {
            _connectToClient = false;
            _runServer = false;
        }
        public void SendMessage(byte[] message)
        {
            _networkStream.Write(message, 0, message.Length);
            _networkStream.Flush();
        }
        public void DisconnectClient()
        {
            _connectToClient = false;
        }
        #endregion
        #region Private Methods
        private void RunServerEngine(Object obj)
        {
            try
            {
                _isRunning = true;
                while (_runServer)
                {
                    Thread.Sleep(250);
                    if (_tcpListener.Pending())
                    {
                        using (_tcpClient = _tcpListener.AcceptTcpClient())
                        {
                            var socketForClient = _tcpClient.Client;
                            _networkStream = new NetworkStream(socketForClient);
                            RaiseOnConnectionOpened((IPEndPoint)_tcpClient.Client.RemoteEndPoint);
                            _connectToClient = true;
                            while (_connectToClient)
                            {
                                if (CheckClientConnection() == false)
                                {
                                    _connectToClient = false;
                                    break;
                                }
                                if (_networkStream.DataAvailable)
                                {
                                    var bytes = new Byte[1024];
                                    _networkStream.Read(bytes, 0, 1024);
                                    bytes = bytes.TakeWhile(b => b > 0).ToArray();
                                    RaiseOnMessageReceived(bytes);
                                }
                                Thread.Sleep(100);
                            }
                        }
                        RaiseOnConnectionClosed();
                    }
                }
                RaiseOnLogMessage(LogLevel.Info, "Stopping TCP Server");
                _tcpListener.Stop();
                _isRunning = false;
                RaiseOnLogMessage(LogLevel.Info, "TCP Server stopped");
            }
            catch (Exception ex)
            {
                RaiseOnLogMessage(LogLevel.Error, String.Format("Fatal error in TCP Server, {0}", ex.ToString()));
                throw;
            }
        }
        private bool CheckClientConnection()
        {
            var connected = true;
            try
            {
                var pollResult = _tcpClient.Client.Poll(1, SelectMode.SelectRead);
                var dataAvailable = _tcpClient.Client.Available;
                connected = !(pollResult && _tcpClient.Client.Available == 0);
                if (!connected)
                {
                    RaiseOnLogMessage(LogLevel.Info, "Detected disconnection from client");
                    RaiseOnLogMessage(LogLevel.Info, String.Format("TCPServer.CheckClientConnection - connected: {0}, pollResult: {1}, dataAvailable: {2}", connected, pollResult, dataAvailable));
                }
            }
            catch (SocketException ex)
            {
                RaiseOnLogMessage(LogLevel.Info, String.Format("Exception occurred in TCPServer.CheckClientConnection. Ex: {0}", ex.ToString()));
                connected = false;
            }
            return connected;
        }
        private void RaiseOnMessageReceived(byte[] message)
        {
            if (OnMessageReceived != null)
            {
                try
                {
                    OnMessageReceived(message);
                }
                catch (Exception ex)
                {
                    RaiseOnLogMessage(LogLevel.Warning, ex.Message);
                }
            }
        }
        private void RaiseOnConnectionOpened(IPEndPoint remoteEndpoint)
        {
            if (OnConnectionOpened != null)
            {
                var msg = String.Format("Connected to client with ip address: {0}, port: {1}", remoteEndpoint.Address, remoteEndpoint.Port);
                OnConnectionOpened(msg);
            }
        }
        private void RaiseOnConnectionClosed()
        {
            if (OnConnectionClosed != null)
                OnConnectionClosed("Disconnected from client");
        }
        private void RaiseOnLogMessage(LogLevel level, string message)
        {
            if (OnLogMessage != null)
                OnLogMessage(level, message);
        }
        #endregion
    }
