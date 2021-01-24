    public static long? FromIpv4ToLong(this string ipAddress)
    {
       var octets = ipAddress.Split(IpSplitChar);
       if (octets.Length != 4) return null;
       if (long.TryParse(octets[0], out long a)
                    && long.TryParse(octets[1], out long b)
                    && long.TryParse(octets[2], out long c)
                    && long.TryParse(octets[3], out long d)){
           return ((16777216L * a) + (65536L * b) + (256L * c) + d);
       }
       return null;
    }
