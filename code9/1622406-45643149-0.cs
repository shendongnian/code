    while (client.Connected)
    {
        byte[] bytesToRead = new byte[client.ReceiveBufferSize];
        int bytesRead = s.Read(bytesToRead, 0, client.ReceiveBufferSize);
       Console.Write(Encoding.ASCII.GetString(bytesToRead, 0, bytesRead));
    }
