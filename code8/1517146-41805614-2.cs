    async void Call()
    {
        TcpSocketClient client = new TcpSocketClient();
        await client.ConnectAsync("192.168.222.1", 5555);
        byte[] Data = new byte[] { 0x01, 0x08, 0, 0, 0, 0, 0xe0, 0x0b }
        await client.WriteStream.WriteAsync(Data, 0, 8);
        byte[] finalData = new byte[8];
        int read = await client.ReadStream.ReadAsync(finalData, 0, 8);
        //Check here, read will have the number of bytes read.
    }
