    public string GetMACAddress()
    {
        NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
        string macAddress = string.Empty;
        foreach (NetworkInterface adapter in nics)
        {
            if (macAddress == String.Empty)
            {
                var properties = adapter.GetIPProperties();
                macAddress = adapter.GetPhysicalAddress().ToString();
            }
        } return macAddress;
    }
