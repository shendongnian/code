    static bool Verify(string text, byte[] signature, string certPath)
    {
        X509Certificate2 cert = new X509Certificate2( certPath );
        using( RSA rsa = cert.GetRSAPublicKey() )
        using( SHA1Managed sha1 = new SHA1Managed() )
        {
            byte[] data = Encoding.Unicode.GetBytes( text );
            byte[] hash = sha1.ComputeHash( data );
            return rsa.VerifyHash( hash, CryptoConfig.MapNameToOID("SHA1"), signature );
        }
    }
