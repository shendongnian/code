    public void Start()
    {
        Console.WriteLine("Server started...");
        TcpListener listener = new TcpListener(System.Net.IPAddress.Loopback, 1234);
        listener.Start();
        while (true)
        {
            TcpClient client = listener.AcceptTcpClient();
            new Thread(new ThreadStart(() =>
            {
                HandleClient(client);
            })).Start();
        }
    }
     private void HandleClient(TcpClient client)
     {
        NetworkStream stream = client.GetStream();
        StreamWriter writer = new StreamWriter(stream, Encoding.ASCII) { AutoFlush = true };
        StreamReader reader = new StreamReader(stream, Encoding.ASCII);
        string inputLine = reader.ReadLine();
        Console.WriteLine("The client with name " + " " + inputLine + " is conected");
    }
