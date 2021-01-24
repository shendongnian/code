    public void VerifySignedData(byte[] originalData, byte[] signedData, X509Certificate2 certificate)
    {
        using (var rsa = (RSACryptoServiceProvider)certificate.PublicKey.Key)
        {
            if (rsa.VerifyData(originalData, CryptoConfig.MapNameToOID("SHA256"), signedData))
            {
                Console.WriteLine("RSA-SHA256 signature verified");
            }
            else
            {
                Console.WriteLine("RSA-SHA256 signature failed to verify");
            }
        }
    }
