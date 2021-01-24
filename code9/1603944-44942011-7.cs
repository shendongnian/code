    /// <summary>
    /// Event arguments for the <see cref="ChatServer.Status"/> event
    /// </summary>
    public class StatusEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the status text
        /// </summary>
        public string StatusText { get; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="statusText">The status text</param>
        public StatusEventArgs(string statusText)
        {
            StatusText = statusText;
        }
    }
    /// <summary>
    /// A server implementing a simple line-based chat server
    /// </summary>
    public class ChatServer
    {
        private readonly object _lock = new object();
        private readonly Socket _listener;
        private readonly List<ConnectedEndPoint> _clients = new List<ConnectedEndPoint>();
        private bool _closing;
        /// <summary>
        /// Gets a task representing the listening state of the servdere
        /// </summary>
        public Task ListenTask { get; }
        /// <summary>
        /// Raised when the server has status to report
        /// </summary>
        public event EventHandler<StatusEventArgs> Status;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="port">The port number the server should listen on</param>
        public ChatServer(int port)
        {
            _listener = new Socket(SocketType.Stream, ProtocolType.Tcp);
            _listener.Bind(new IPEndPoint(IPAddress.Any, port));
            _listener.Listen(int.MaxValue);
            ListenTask = _ListenAsync();
        }
        /// <summary>
        /// Initiates a shutdown of the chat server.
        /// </summary>
        /// <remarks>This method closes the listening socket, which will subsequently
        /// cause the listening task to inform any connected clients that the server
        /// is shutting down, and to wait for the connected clients to finish a graceful
        /// closure of their connections.
        /// </remarks>
        public void Shutdown()
        {
            _listener.Close();
        }
        private async Task _ListenAsync()
        {
            try
            {
                while (true)
                {
                    ConnectedEndPoint client = await ConnectedEndPoint.AcceptAsync(_listener, _ClientReadLine);
                    _AddClient(client);
                    _CleanupClientAsync(client);
                }
            }
            catch (ObjectDisposedException)
            {
                _OnStatus("Server's listening socket closed");
            }
            catch (IOException e)
            {
                _OnStatus($"Listening socket IOException: {e.Message}");
            }
            await _CleanupServerAsync();
        }
        private async Task _CleanupServerAsync()
        {
            ConnectedEndPoint[] clients;
            lock (_lock)
            {
                _closing = true;
                clients = _clients.ToArray();
            }
            foreach (ConnectedEndPoint client in clients)
            {
                try
                {
                    client.WriteLine("Chat server is shutting down");
                }
                catch (IOException e)
                {
                    _OnClientException(client, e.Message);
                }
                client.Shutdown();
            }
            // Clients are expected to participate in graceful closure. If they do,
            // this will complete when all clients have acknowledged the shutdown.
            // In a real-world program, may be a good idea to include a timeout in
            // case of network issues or misbehaving/crashed clients. Implementing
            // the timeout is beyond the scope of this proof-of-concept demo code.
            try
            {
                await Task.WhenAll(clients.Select(c => c.ReadTask));
            }
            catch (AggregateException)
            {
                // Actual exception for each client will have already
                // been reported by _CleanupClientAsync()
            }
        }
        // Top-level "clean-up" method, which will observe and report all exceptions
        // In real-world code, would probably want to simply log any unexpected exceptions
        // to a log file and then exit the process. Here, we just exit after reporting
        // exception info to caller. In either case, there's no need to observe a Task from
        // this method, and async void simplifies the call (no need to receive and then ignore
        // the Task object just to keep the compiler quiet).
        private async void _CleanupClientAsync(ConnectedEndPoint client)
        {
            try
            {
                await client.ReadTask;
            }
            catch (IOException e)
            {
                _OnClientException(client, e.Message);
            }
            catch (Exception e)
            {
                // Unexpected exceptions are programmer-error. They could be anything, and leave
                // the program in an unknown, possibly corrupt state. The only reasonable disposition
                // is to log, then exit.
                //
                // Full stack-trace, because who knows what this exception was. Will need the
                // stack-trace to do any diagnostic work.
                _OnStatus($"Unexpected client connection exception. {e}");
                Environment.Exit(1);
            }
            finally
            {
                _RemoveClient(client);
                client.Dispose();
            }
        }
        private void _ClientReadLine(ConnectedEndPoint readClient, string text)
        {
            _OnStatus($"Client {readClient.RemoteEndPoint}: \"{text}\"");
            lock (_lock)
            {
                if (_closing)
                {
                    return;
                }
                text = $"{readClient.RemoteEndPoint}: {text}";
                foreach (ConnectedEndPoint client in _clients.Where(c => c != readClient))
                {
                    try
                    {
                        client.WriteLine(text);
                    }
                    catch (IOException e)
                    {
                        _OnClientException(client, e.Message);
                    }
                }
            }
        }
        private void _AddClient(ConnectedEndPoint client)
        {
            lock (_lock)
            {
                _clients.Add(client);
                _OnStatus($"added client {client.RemoteEndPoint} -- {_clients.Count} clients connected");
            }
        }
        private void _RemoveClient(ConnectedEndPoint client)
        {
            lock (_lock)
            {
                _clients.Remove(client);
                _OnStatus($"removed client {client.RemoteEndPoint} -- {_clients.Count} clients connected");
            }
        }
        private void _OnStatus(string statusText)
        {
            Status?.Invoke(this, new StatusEventArgs(statusText));
        }
        private void _OnClientException(ConnectedEndPoint client, string message)
        {
            _OnStatus($"Client {client.RemoteEndPoint} IOException: {message}");
        }
    }
