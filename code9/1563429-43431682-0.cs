    class Program
    {
        static readonly object _lock = new object();
        static readonly Dictionary<int, TcpClient> list_clients = new Dictionary<int, TcpClient>();
        static void Main(string[] args)
        {
            int count = 1;
            TcpListener ServerSocket = new TcpListener(IPAddress.Any, 5000);
            ServerSocket.Start();
            while (true)
            {
                TcpClient client = ServerSocket.AcceptTcpClient();
                lock (_lock) list_clients.Add(count, client);
                Console.WriteLine("Someone connected!!");
                Thread t = new Thread(handle_clients);
                t.Start(count);
                count++;
            }
        }
        public static void handle_clients(object o)
        {
            int id = (int)o;
            TcpClient client;
            
            lock (_lock) client = list_clients[id];
            while (true)
            {
                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[1024];
                int byte_count = stream.Read(buffer, 0, buffer.Length);
                if (byte_count == 0)
                {
                    break;
                }
                string data = Encoding.ASCII.GetString(buffer, 0, byte_count);
                broadcast(data);
                Console.WriteLine(data);
            }
            lock (_lock) list_clients.Remove(id);
            client.Client.Shutdown(SocketShutdown.Both);
            client.Close();
        }
        public static void broadcast(string data)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(data + Environment.NewLine);
            lock (_lock)
            {
                foreach (TcpClient c in list_clients.Values)
                {
                    NetworkStream stream = c.GetStream();
                    stream.Write(buffer, 0, buffer.Length);
                }
            }
        }
    }
