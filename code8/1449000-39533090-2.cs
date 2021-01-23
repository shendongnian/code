    private List<byte[]> datagrams = new List<byte[]>();
    public void serverThread()
    {
        UdpClient udpClient = new UdpClient(Convert.ToInt16(tbEthPort.Text));
        while (_serverWork)
        {
            try
            {
                IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, Convert.ToInt16(tbEthPort.Text));
                Byte[] receiveBytes = udpClient.Receive(ref RemoteIpEndPoint);
                // add to the queue
                lock (datagrams)
                    datagrams.Add(receiveBytes);
            }
        }
    }
