    public static long CastIp(string ip)
    {
        IPAddress address = IPAddress.Parse(ip);
        byte[] addressBytes = address.GetAddressBytes();
        // This restriction is implicit in your existing code, but
        // it would currently just lose data...
        if (addressBytes.Length != 4)
        {
            throw new ArgumentException("Must be an IPv4 address");
        }
        int networkOrder = BitConverter.ToInt32(addressBytes, 0);
        return (uint) IPAddress.NetworkToHostOrder(networkOrder);
    }
