    public static long? FromIpv4ToLong(this string ipAddress)
    {
        var octets = ipAddress.Split(IpSplitChar);
        return octets.Length == 4
            && long.TryParse(octets[0], out long a)
            && long.TryParse(octets[1], out long b)
            && long.TryParse(octets[2], out long c)
            && long.TryParse(octets[3], out long d)
            ? (a << 24) | (b << 16) + (c << 8) | d
            : null;
    }
