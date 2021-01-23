    static void connect(string server, int port)
    {
        TcpClient client = new TcpClient(); // New instance of TcpClient class of the .Net.Sockets
        client.Connect(server, port); // Server, Port
        StreamWriter sw = new StreamWriter(client.GetStream()); // New StreamWriter instance
        StreamReader sr = new StreamReader(client.GetStream()); // New StreamReader instance
    }
