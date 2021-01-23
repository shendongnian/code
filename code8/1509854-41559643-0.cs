    TcpClient client;
    private void ConnectAsClient()
    {           
        //client.Connect(IPAddress.Parse(textBox.Text), 5004);
        client = new TcpClient();
        //client.Connect(IPAddress.Parse("127.0.0.1"), 2016);
        client.Connect(IPAddress.Parse("my_ip_here"), 2016);
        updateUI("connected");
    }
    void SendMessage()
    {
        NetworkStream stream = client.GetStream();
        string s = "Hello world!";
        byte[] message = Encoding.ASCII.GetBytes(s);
        stream.Write(message, 0, message.Length);
        this.updateUI("Message sent!");
    }`
