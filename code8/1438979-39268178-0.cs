            static void Main(string[] args)
        {
            UdpClient udpServer = new UdpClient(1100);
            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);
            TcpListener listener = new TcpListener(IPAddress.Any, 25655);
            listener.Start();
            Socket sck = listener.AcceptTcpClient().Client;
            var data = udpServer.Receive(ref remoteEP);
            string result = Encoding.UTF8.GetString(data);
            Console.WriteLine(result);
            Console.Read();
        }
