        private static readonly List<EndPoint> clients = new List<EndPoint>();
        private static readonly SocketAsyncEventArgs receiveEventArgs = new SocketAsyncEventArgs();
        private static Socket socket;
        private static void Main(string[] args)
        {
            receiveEventArgs.Completed += OnReceive;
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            socket.Bind(new IPEndPoint(IPAddress.Any, 6000));
            Receive();
            while (true)
            {
                Thread.Sleep(3000);
                lock (clients)
                {
                    foreach (var endPoint in clients)
                        socket.SendTo(Encoding.ASCII.GetBytes("PING"), endPoint);
                }
            }
        }
        private static void Receive()
        {
            receiveEventArgs.SetBuffer(new byte[256], 0, 256);
            receiveEventArgs.RemoteEndPoint = new IPEndPoint(IPAddress.Any, 6000);
            socket.ReceiveFromAsync(receiveEventArgs);
        }
        private static void OnReceive(object sender, SocketAsyncEventArgs e)
        {
            if (e.BytesTransferred > 0)
            {
                // Is reply?
                var isReply = true/false;
                if (isReply)
                {
                    // Do domething
                }
                else
                    lock (clients)
                    {
                        clients.Add(e.RemoteEndPoint);
                    }
            }
            else
            {
                lock (clients)
                {
                    clients.Remove(e.RemoteEndPoint);
                }
            }
            Receive();
        }
