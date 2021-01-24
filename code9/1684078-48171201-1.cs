    client = new TcpClient("192.168.1.85", 64000);
    NetworkStream stream = client.GetStream();
    Byte[] dataReceive = new Byte[256];
    String responseData = String.Empty;
    Int32 bytes;
    while ((bytes = stream.Read(dataReceive, 0, dataReceive.Length)) != 0)
    {
        responseData = System.Text.Encoding.ASCII.GetString(dataReceive, 0, bytes);
        txtReceive.Text += responseData;
    }
    stream.Close();
