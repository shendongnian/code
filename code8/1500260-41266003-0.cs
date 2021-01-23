    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        TcpClient client = new TcpClient();
        client.Client.Connect(IPAddress.Parse("192.168.100.5"), 8000);
        //Task.Run(() => ReadData(client));
        Task.Run(() => ReadDataLoop(client));
        client.Client.Send(Encoding.ASCII.GetBytes("{\"TID\":1111,\"blabla\":{}}"));
        while (true)
        {
        }
    }
    private static void ReadDataLoop(TcpClient client)
    {
        while (true)
        {
            if (!client.Connected)
                break;
            string xxx = "";
            xxx = ReadData(client);
            Console.WriteLine(xxx);
        }
    }
    private static string ReadData(TcpClient client)
    {
        string retVal;
        byte[] data = new byte[1024];
        NetworkStream stream = client.GetStream();
        byte[] myReadBuffer = new byte[1024];
        StringBuilder myCompleteMessage = new StringBuilder();
        int numberOfBytesRead = 0;
        do
        {
            numberOfBytesRead = stream.Read(myReadBuffer, 0, myReadBuffer.Length);
            myCompleteMessage.AppendFormat("{0}", Encoding.ASCII.GetString(myReadBuffer, 0, numberOfBytesRead));
        }
        while (stream.DataAvailable);
        retVal = myCompleteMessage.ToString();
        return retVal;
    }
