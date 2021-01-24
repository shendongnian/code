    TcpClient client = new TcpClient("192.168.200.91", 2101);
    NetworkStream netStream = client.GetStream();
    byte[] bytes = new byte[client.ReceiveBufferSize];
    int bytesRead = netStream.Read(bytes, 0, (int)client.ReceiveBufferSize);
    string returndata = BitConverter.ToString(bytes, 0, bytesRead).Replace("-", "")
    using (var writer = new StreamWriter(@"C:\Users\ -\Documents\test.txt", false, Encoding.UTF8))
    {
        writer.WriteLine(returndata);
    }
