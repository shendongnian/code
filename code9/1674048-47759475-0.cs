    private void readFromConnection()
    {
        while (true)
        {
            if(client.Connected && client.Available > 0)
            {
                string x1 = string.Empty;
                byte[] bytesToRead = new byte[client.Available];
                int bytesRead = client.Client.Receive(bytesToRead);
                x1 = System.Text.Encoding.Default.GetString(bytesToRead);
            }
            Thread.Sleep(500);
        }
    }
