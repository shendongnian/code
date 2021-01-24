    private IPAddress ip;
   
    void Start()
    {
        ip = Dns.GetHostAddresses("HOSTNAME")[0];
        client = new UdpClient(new IPEndPoint(IPAddress.Any, 0));
        udpThread = new Thread(new ThreadStart(ReadMessage))
        {
            IsBackground = true  
        };
        udpThread.Start();
    }
 
    private void ReadMessage()
    {
        while (true)
        {
            try
            {
                IPEndPoint IPEP = null;
                byte[] data = client.Receive(ref IPEP);
                string message = Encoding.ASCII.GetString(data);
            }
        }
    }
    public void SendUDP(string message)
    {
        client.Send(Encoding.ASCII.GetBytes(message), message.Length, new IPEndPoint(ip, 8888));
    }
