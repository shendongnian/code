    const int port = 29500;
    using (var client = new TcpClient())
        client.Connect(IPAddress.Loopback, port);
    using (var client = new TcpClient())
        client.Connect(IPAddress.Loopback, port);
