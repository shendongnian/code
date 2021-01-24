    private TcpClient client { get; set; }
    private string ipAddressString = "127.0.0.1";
    private int port = 5550;
    private void btnSend_Click(object sender, EventArgs e)
    {
        IPAddress ipAddress = IPAddress.Parse(ipAddressString);
        TcpClient client = getConnection(ipAddress);
        sendServerMessage(client, textBox2.Text);
    }
    private TcpClient getConnection(IPAddress ipAddress)
    {
        if (client == null)
            client = new TcpClient();
        if (!client.Connected)
            client.Connect(ipAddress, port);
        return client;
    }
    private void sendServerMessage(TcpClient client, string message)
    {
        Stream messageStream = client.GetStream();
        ASCIIEncoding encoder = new ASCIIEncoding();
        byte[] encodedMessage = encoder.GetBytes(message);
        messageStream.Write(encodedMessage, 0, encodedMessage.Length);
        messageStream.Flush();
    }
