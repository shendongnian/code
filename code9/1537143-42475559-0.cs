    private async void ListenForClientsAsync()
    {
        try
        {
            while (true)
            {
                var client = await Server.AcceptTcpClientAsync();
                if (client.Connected)
                {
                    ServerView.UpdateChatBox("Client connected.");
                    await ReadStreamAsync(client);
                }
            }
        }
        catch (Exception e)
        {
            ServerView.UpdateChatBox(e.Message);
        }
    }
    private async Task ReadStreamAsync(TcpClient client)
    {
        NetworkStream streamer = client.GetStream();
        Byte[] buff = new Byte[1024];
        String msg;
        int buffRecived;
        // receive data until connection is closed, i.e. receive completes
        // with 0-byte length.
        while ((buffRecived = await streamer.ReadAsync(buff, 0, buff.Length)) > 0)
        {
            msg = System.Text.Encoding.ASCII.GetString(buff);
            ServerView.UpdateChatBox(msg);
        }
    }
