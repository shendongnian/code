    public static void Main(string[] args)
    {
        ...
        var armIpAddress = IPAddress.Parse("239.1.11.1");
        using (var udpClient = new UdpClient())
        {
            udpClient.ExclusiveAddressUse = false;
            .......
            while (true)
            {
                return; 
            }
        }
    }
