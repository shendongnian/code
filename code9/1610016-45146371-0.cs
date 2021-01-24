    public async Task Connection()
    {
        TcpListener server = new TcpListener(IPAddress.Any, 5030);
        server.Start();
        while (true)
        {
            System.Console.WriteLine("Waiting for client");
            TcpClient client = await server.AcceptTcpClientAsync();
            ProcessClient(TcpClient client);              
        }
    }
