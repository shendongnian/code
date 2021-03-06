    private static bool IsBrazilA1Certificate(X509Certificate2 cert)
    {
        // End with the "." so it matches on children, but not that OID.
        return HasParentEku(cert, "2.16.76.1.2.1.");
    }
    private static bool IsBrazilA3Certificate(X509Certificate2 cert)
    {
        // End with the "." so it matches on children, but not that OID.
        return HasParentEku(cert, "2.16.76.1.2.3.");
    }
    private static bool HasParentEku(X509Certificate2 cert, string oidFragment)
    {
        var ekuExtension = (X509EnhancedKeyUsageExtension) cert.Extensions["2.5.29.37"];
        if (ekuExtension == null)
        {
            return false;
        }
        foreach (Oid eku in ekuExtension.EnhancedKeyUsages)
        {
            if (eku.Value.StartsWith(oidFragment))
            {
                return true;
            }
        }
        return false;
    }
