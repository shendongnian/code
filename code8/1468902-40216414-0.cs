        protected const int SIZE_RECEIVE_BUFFER = 1024; /// Receive buffer size
        protected const string EOF = "!#~*|"; /// End of packet string
        MemoryStream _msPacket = new MemoryStream(); /// Memory stream holding buffered data packets
        int _delmtPtr = 0; /// Ranking pointer to check for EOF 
        Socket _baseSocket;
        public event EventHandler OnReceived;
        // TODO: -
        // Add methods to connect or accept connections.
        // When data is send to receiver, send with the same EOF defined above.
        //
        //
        public void RegisterToReceive()
        {
            byte[] ReceiveBuffer = new byte[SIZE_RECEIVE_BUFFER];
            _baseSocket.BeginReceive
            (
                ReceiveBuffer,
                0,
                ReceiveBuffer.Length,
                SocketFlags.None,
                new AsyncCallback(onReceiveData),
                ReceiveBuffer
            );
        }
        private void onReceiveData(IAsyncResult async)
        {
            try
            {
                byte[] buffer = (byte[])async.AsyncState;
                int bytesCtr = 0;
                try
                {
                    if (_baseSocket != null)
                        bytesCtr = _baseSocket.EndReceive(async);
                }
                catch { }
                if (bytesCtr > 0)
                    processReceivedData(buffer, bytesCtr);
                RegisterToReceive();
            }
            catch{ }
        }
        private void processReceivedData(byte[] buffer, int bufferLength)
        {
            byte[] eof = Encoding.UTF8.GetBytes(EOF);
            int packetStart = 0;
            for (int i = 0; i < bufferLength; i++)
            {
                if (buffer[i].Equals(eof[_delmtPtr]))
                {
                    _delmtPtr++;
                    if (_delmtPtr == eof.Length)
                    {
                        var lenToWrite = i - packetStart - (_delmtPtr - 1);
                        byte[] packet = new byte[lenToWrite + (int)_msPacket.Position];
                        if (lenToWrite > 0)
                            _msPacket.Write(buffer, packetStart, lenToWrite);
                        packetStart = i + 1;
                        _msPacket.Position = 0;
                        _msPacket.Read(packet, 0, packet.Length);
                        try
                        {
                            if (OnReceived != null)
                                OnReceived(packet, EventArgs.Empty);
                        }
                        catch { }
                        _msPacket.Position = 0;
                        _delmtPtr = 0;
                    }
                }
                else
                { _delmtPtr = 0; }
            }
            if (packetStart < bufferLength)
                _msPacket.Write(buffer, packetStart, bufferLength - packetStart);
            if (_msPacket.Position == 0)
                _msPacket.SetLength(0);
        }
