    static void GetIpAddress()
    {
        foreach (NetworkInterface netif in NetworkInterface.GetAllNetworkInterfaces())
        {
    
            IPInterfaceProperties properties = netif.GetIPProperties();
    
            foreach (IPAddressInformation unicast in properties.UnicastAddresses)
            {
                Console.WriteLine(unicast.Address);
            }
            
        }
    }
