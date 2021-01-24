    class Program
    {
        private static readonly object _lock = new object();
        private static readonly List<TcpClient> clients = new List<TcpClient>();
        public static TcpClient[] GetClients()
        {
            lock (_lock) return clients.ToArray();
        }
        public static int GetClientCount()
        {
            lock (_lock) return clients.Count;
        }
        public static void RemoveClient(TcpClient client)
        {
            lock (_lock) clients.Remove(client);
        }
        static void Main(string[] args)
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            TcpListener ServerSocket = new TcpListener(ip, 14000);
            ServerSocket.Start();
            Console.WriteLine("Server started.");
            while (true)
            {
                TcpClient clientSocket = ServerSocket.AcceptTcpClient();
                Console.WriteLine($"client connected: {clientSocket.Client.RemoteEndPoint}");
                lock (_lock) clients.Add(clientSocket);
                handleClient client = new handleClient();
                client.startClient(clientSocket);
                Console.WriteLine($"{GetClientCount()} clients connected");
            }
        }
    }
