    public static bool Verify(byte[] payment, byte[] signature)
    {
        var key = Resources.PublicKey;
        // Change the function this calls to return RSACng instead of RSACryptoServiceProvider.
        RSA cipher = Crypto.DecodeX509PublicKey(key);
        // or, failing being able to change it:
        RSA tmp = new RSACng();
        tmp.ImportParameters(cipher.ExportParameters(false));
        cipher = tmp;
        return cipher.VerifyData(
            payment,
            signature,
            HashAlgorithmName.SHA256,
            RSASignaturePadding.Pss);
     }
