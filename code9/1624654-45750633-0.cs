        public ServerClient(int id, Socket s, ClientConnectedDelegate connected, ClientDisconnectedDelegate disconnected)
        {
            //
            Id = id;
            //
            _connection = s;
            _disconnected = disconnected;
            //
            Ip = _connection.RemoteIp();
            //
            _connection.ReceiveBufferSize = ServerExt.ReadBufferSize;
            _connection.SendBufferSize = ServerExt.SendBufferSize;
            _connection.NoDelay = true;
            //
            _netStream = new NetworkStream(_connection, FileAccess.ReadWrite);
            //
            if (_cert != null)
            {
                _ssl = new SslStream(_netStream, false);
                _ssl.AuthenticateAsServer(_cert, false, SslProtocols.Tls, true);
                // 
                _br = new BinaryReader(_ssl, Encoding.UTF8, false);
                _bw = new BinaryWriter(_ssl, Encoding.UTF8, false);
            }
            else
            {
                _br = new BinaryReader(_netStream, Encoding.UTF8, false);
                _bw = new BinaryWriter(_netStream, Encoding.UTF8, false);
            }
            //
            Task.Factory.StartNew(ListenToClient);
            //
            connected(this);
        }
