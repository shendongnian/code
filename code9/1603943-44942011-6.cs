    /// <summary>
    /// Represents a remote end-point for the chat server and clients
    /// </summary>
    public sealed class ConnectedEndPoint : IDisposable
    {
        private readonly object _lock = new object();
        private readonly Socket _socket;
        private readonly StreamReader _reader;
        private readonly StreamWriter _writer;
        private bool _closing;
        /// <summary>
        /// Gets the address of the connected remote end-point
        /// </summary>
        public IPEndPoint RemoteEndPoint { get { return (IPEndPoint)_socket.RemoteEndPoint; } }
        /// <summary>
        /// Gets a <see cref="Task"/> representing the on-going read operation of the connection
        /// </summary>
        public Task ReadTask { get; }
        /// <summary>
        /// Connect to an existing remote end-point (server) and return the
        /// <see cref="ConnectedEndPoint"/> object representing the new connection
        /// </summary>
        /// <param name="remoteEndPoint">The address of the remote end-point to connect to</param>
        /// <param name="readCallback">The callback which will be called when a line of text is read from the newly-created connection</param>
        /// <returns></returns>
        public static ConnectedEndPoint Connect(IPEndPoint remoteEndPoint, Action<ConnectedEndPoint, string> readCallback)
        {
            Socket socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(remoteEndPoint);
            return new ConnectedEndPoint(socket, readCallback);
        }
        /// <summary>
        /// Asynchronously accept a new connection from a remote end-point
        /// </summary>
        /// <param name="listener">The listening <see cref="Socket"/> which will accept the connection</param>
        /// <param name="readCallback">The callback which will be called when a line of text is read from the newly-created connection</param>
        /// <returns></returns>
        public static async Task<ConnectedEndPoint> AcceptAsync(Socket listener, Action<ConnectedEndPoint, string> readCallback)
        {
            Socket clientSocket = await Task.Factory.FromAsync(listener.BeginAccept, listener.EndAccept, null);
            return new ConnectedEndPoint(clientSocket, readCallback);
        }
        /// <summary>
        /// Write a line of text to the connection, sending it to the remote end-point
        /// </summary>
        /// <param name="text">The line of text to write</param>
        public void WriteLine(string text)
        {
            lock (_lock)
            {
                if (!_closing)
                {
                    _writer.WriteLine(text);
                    _writer.Flush();
                }
            }
        }
        /// <summary>
        /// Initiates a graceful closure of the connection
        /// </summary>
        public void Shutdown()
        {
            _Shutdown(SocketShutdown.Send);
        }
        /// <summary>
        /// Implements <see cref="IDisposable.Dispose"/>
        /// </summary>
        public void Dispose()
        {
            _reader.Dispose();
            _writer.Dispose();
            _socket.Close();
        }
        /// <summary>
        /// Constructor. Private -- use one of the factory methods to create new connections.
        /// </summary>
        /// <param name="socket">The <see cref="Socket"/> for the new connection</param>
        /// <param name="readCallback">The callback for reading lines on the new connection</param>
        private ConnectedEndPoint(Socket socket, Action<ConnectedEndPoint, string> readCallback)
        {
            _socket = socket;
            Stream stream = new NetworkStream(_socket);
            _reader = new StreamReader(stream, Encoding.UTF8, false, 1024, true);
            _writer = new StreamWriter(stream, Encoding.UTF8, 1024, true);
            ReadTask = _ConsumeSocketAsync(readCallback);
        }
        private void _Shutdown(SocketShutdown reason)
        {
            lock (_lock)
            {
                if (!_closing)
                {
                    _socket.Shutdown(reason);
                    _closing = true;
                }
            }
        }
        private async Task _ConsumeSocketAsync(Action<ConnectedEndPoint, string> callback)
        {
            string line;
            while ((line = await _reader.ReadLineAsync()) != null)
            {
                callback(this, line);
            }
            _Shutdown(SocketShutdown.Both);
        }
    }
