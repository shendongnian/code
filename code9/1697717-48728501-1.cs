    public string GetHashFromFingerPrintData(byte[] fingerPrintData)
    {
        using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider())
        {
            return Convert.ToBase64String(sha1.ComputeHash(fingerPrintData));
        }
    }
