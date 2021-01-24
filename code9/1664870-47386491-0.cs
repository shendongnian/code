    private IPAddress GetFirstPrivateIp(bool ipV4) {
        var interfaces = NetworkInterface.GetAllNetworkInterfaces();
        return interfaces
            .SelectMany(c => c.GetIPProperties().UnicastAddresses)
            .Where(c => 
                !IPAddress.IsLoopback(c.Address)
                && c.Address.AddressFamily == (ipV4 ? AddressFamily.InterNetwork : AddressFamily.InterNetworkV6)
                && (!ipV4 || IpIsPrivate(c.Address))) // IpIsPrivate - refer to question linked above
            .Select(c => c.Address)
            .FirstOrDefault();
    }
