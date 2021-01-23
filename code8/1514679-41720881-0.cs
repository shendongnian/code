    public async Task Initialize(string ip, int port)
    {
        tcpClient = new TcpClient;
        await tcpClient.ConnectAsync(ip, port);
        Console.WriteLine("Connected to: {0}:{1}", ip, port);
    }
    public async Task Read()
    {
        var buffer = new byte[4096];
        var ns = tcpClient.GetStream();
        while (true)
        {
            var bytesRead = ns.ReadAsync(buffer, 0, buffer.Length);
            if (bytesRead == 0) return; // Stream was closed
            Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, bytesRead));
        }
    }
