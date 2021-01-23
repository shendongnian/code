    IPAddress ipAddress = null;
    foreach (NetworkInterface networkInterface in NetworkInterface.GetAllNetworkInterfaces())
    {
        IPInterfaceProperties ipIntProperties = networkInterface.GetIPProperties();
        foreach (UnicastIPAddressInformation addr in ipIntProperties.UnicastAddresses)
        {
            String addressWithoutScopeId = addr.Address.ToString().Split('%')[0];
            if (addressWithoutScopeId.Equals("fe80::2"))
            {
                ipAddress = addr.Address;
                break;
             }
         }
         if (ipAddress != null)
             break;
    }
    var endPoint = new IPEndPoint(ipAddress, 0);
    TcpClient client = new TcpClient(endPoint);
    client.Connect(IPAddress.Parse("fe80::3"), 15000);
    NetworkStream stream = client.GetStream();
    int number = stream.ReadByte();
    stream.Close();
    client.Close();
