    internal static RSA RsaCreate(int keySize)
    {
    #if NETFX
        // If your baseline is .NET 4.6.2 or higher prefer RSACng
        // or 4.6+ if you are never giving the object back to the framework
        // (4.6.2 improved the framework's handling of those objects)
        // On older versions RSACryptoServiceProvider is the only way to go.
        return new RSACng(keySize);
    #else
        RSA rsa = RSA.Create();
        rsa.KeySize = keySize;
        if (rsa.KeySize != keySize)
            throw new Exception("Setting rsa.KeySize had no effect");
        return rsa;
    #endif
    }
