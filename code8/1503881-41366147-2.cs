    public class TcpForwarderSlim
    {
        private readonly Socket _mainSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public void Start(IPEndPoint local, IPEndPoint remote)
        {
            _mainSocket.Bind(local);
            _mainSocket.Listen(10);
            while (true)
            {
                var source = _mainSocket.Accept();
                var destination = new TcpForwarderSlim();
                var state = new State(source, destination._mainSocket);
                destination.Connect(remote, source);
                source.BeginReceive(state.Buffer, 0, state.Buffer.Length, 0, OnDataReceive, state);
            }
        }
        private void Connect(EndPoint remoteEndpoint, Socket destination)
        {
            var state = new State(_mainSocket, destination);
            _mainSocket.Connect(remoteEndpoint);
            _mainSocket.BeginReceive(state.Buffer, 0, state.Buffer.Length, SocketFlags.None, OnDataReceive, state);
        }
        private static void OnDataReceive(IAsyncResult result)
        {
            var state = (State)result.AsyncState;
            try
            {
                var bytesRead = state.SourceSocket.EndReceive(result);
                if (bytesRead > 0)
                {
                    //Start an asyncronous send.
                    var sendAr = state.DestinationSocket.BeginSend(state.Buffer, 0, bytesRead, SocketFlags.None,null,null);
                    //Get or create a new buffer for the state object.
                    var oldBuffer = state.ReplaceBuffer();
                    state.SourceSocket.BeginReceive(state.Buffer, 0, state.Buffer.Length, 0, OnDataReceive, state);
                    
                    //Wait for the send to finish.
                    state.DestinationSocket.EndSend(sendAr);
                    //Return byte[] to the pool.
                    state.AddBufferToPool(oldBuffer);
                }
            }
            catch
            {
                state.DestinationSocket.Close();
                state.SourceSocket.Close();
            }
        }
        private class State
        {
            private readonly ConcurrentBag<byte[]> _bufferPool = new ConcurrentBag<byte[]>();
            private readonly int _bufferSize;
            public Socket SourceSocket { get; private set; }
            public Socket DestinationSocket { get; private set; }
            public byte[] Buffer { get; private set; }
            public State(Socket source, Socket destination)
            {
                SourceSocket = source;
                DestinationSocket = destination;
                _bufferSize = Math.Min(SourceSocket.ReceiveBufferSize, DestinationSocket.SendBufferSize);
                Buffer = new byte[_bufferSize];
            }
            
            /// <summary>
            /// Replaces the buffer in the state object.
            /// </summary>
            /// <returns>The previous buffer.</returns>
            public byte[] ReplaceBuffer()
            {
                byte[] newBuffer;
                if (!_bufferPool.TryTake(out newBuffer))
                {
                    newBuffer = new byte[_bufferSize];
                }
                var oldBuffer = Buffer;
                Buffer = newBuffer;
                return oldBuffer;
            }
            public void AddBufferToPool(byte[] buffer)
            {
                _bufferPool.Add(buffer);
            }
        }
    }
