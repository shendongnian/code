    public class TCPTest
    {
        public static void StartAll()
        {
            Task.Run(() => StartServer());
            Task.Run(() => StartClient());
        }
        static void StartServer()
        {
            TcpListener listener = new TcpListener(IPAddress.Any, 12345);
            listener.Start();
            Console.WriteLine("Server Started");
            while (true)
            {
                var client = listener.AcceptTcpClient();
                Console.WriteLine("A new client is connected");
                ThreadPool.QueueUserWorkItem(ServerTask,client);
            }
        }
        static void ServerTask(object o)
        {
            using (var tcpClient = (TcpClient)o)
            {
                var stream = tcpClient.GetStream();
                var writer = new StreamWriter(stream);
                for (int i = 0; i < 10; i++)
                {
                    writer.WriteLine($"packet #{i + 1}");
                    writer.Flush();
                    Thread.Sleep(1000);
                }
                Console.WriteLine("Server session ended..");
            }
        }
        static void StartClient()
        {
            TcpClient client = new TcpClient();
            client.Connect("localhost", 12345);
            var stream = client.GetStream();
            var reader = new StreamReader(stream);
            string line = "";
            while((line = reader.ReadLine()) != null)
            {
                Console.WriteLine("Client received: "+ line);
            }
            Console.WriteLine("Client detected end of the session");
        }
    }
