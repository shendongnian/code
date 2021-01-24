    static List<IPAddress> GetIpAddress()
    {
        List<IPAddress> AllIps = new List<IPAddress>();
    
        foreach (NetworkInterface netif in NetworkInterface.GetAllNetworkInterfaces())
        {
    
            IPInterfaceProperties properties = netif.GetIPProperties();
    
            foreach (IPAddressInformation unicast in properties.UnicastAddresses)
            {
                AllIps.Add(unicast.Address);
                Console.WriteLine(unicast.Address);
            }
        }
    
        return AllIps;
    }
