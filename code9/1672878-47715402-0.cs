    class Server
    {
        TcpListener server = null;
        public Server(string ip, int port)
        {
            IPAddress localAddr = IPAddress.Parse(ip);
            server = new TcpListener(localAddr, port);
            server.Start();
            StartListener();
        }
        public void StartListener()
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("Waiting for a connection... ");
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Connected!");
                    
                    Thread t = new Thread(new ParameterizedThreadStart(HandleDeivce));
                    t.Start(client);
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
        }
        public void HandleDeivce(Object obj)
        {
            TcpClient client = (TcpClient)obj;
            NetworkStream stream = client.GetStream();
            string data = null;
            Byte[] bytes = new Byte[256];
            int i;
            while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
            {
                data = Encoding.ASCII.GetString(bytes, 0, i);
                Console.WriteLine("{1}: Received: {0}", data, Thread.CurrentThread.ManagedThreadId);
                
                if (data.StartsWith("##"))
                {
                    data = "LOAD";
                }
                else
                {
                    data = "ON";
                }
                byte[] msg = Encoding.ASCII.GetBytes(data);
                stream.Write(msg, 0, msg.Length);
                Console.WriteLine("{1}: Sent: {0}", data, Thread.CurrentThread.ManagedThreadId);
            }
            client.Close();
        }
    }
