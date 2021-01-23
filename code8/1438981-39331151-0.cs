    static void Main(string[] args)
    {
        Task.Factory.StartNew(() => 
        {
            TcpListener listener = new TcpListener(IPAddress.Any, 25655);
            listener.Start();
            Socket sck = listener.AcceptTcpClient().Client;
      
            // ToDo: further actions related to TCP client
        }, TaskCreationOptions.LongRunning);
        UdpClient udpServer = new UdpClient(1100);
        IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);
        var data = udpServer.Receive(ref remoteEP);
        string result = Encoding.UTF8.GetString(data);
        Console.WriteLine(result);
        Console.Read();
    }
