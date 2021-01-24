    public async void StartListener() //non blocking listener
    {
        listener.Start();
        while (true)
        {
            TcpClient client = await listener.AcceptTcpClientAsync().ConfigureAwait(false);
            HandleClient(client);
        }
    }
    private async void HandleClient(TcpClient client)
    {
        NetworkStream networkStream = client.GetStream();
        byte[] bytesFrom = new byte[20];
        int totalRead = 0;
        while(totalRead<20)
        {
            totalRead += await networkStream.ReadAsync(bytesFrom, totalRead, 20-totalRead).ConfigureAwait(false);
        }
        string dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
        string serverResponse = "Received!";
        Byte[] sendBytes = Encoding.ASCII.GetBytes(serverResponse);
        await networkStream.WriteAsync(sendBytes, 0, sendBytes.Length).ConfigureAwait(false);
        networkStream.Flush(); /* Not sure necessary */
    }
