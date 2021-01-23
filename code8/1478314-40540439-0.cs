    private string strAlgNameUsed;
    
    public string GetMD5Hash(String strMsg)
    {
        string strAlgName = HashAlgorithmNames.Md5;
        IBuffer buffUtf8Msg = CryptographicBuffer.ConvertStringToBinary(strMsg, BinaryStringEncoding.Utf8);
    
        HashAlgorithmProvider objAlgProv = HashAlgorithmProvider.OpenAlgorithm(strAlgName);
        strAlgNameUsed = objAlgProv.AlgorithmName;
    
        IBuffer buffHash = objAlgProv.HashData(buffUtf8Msg);
    
        if (buffHash.Length != objAlgProv.HashLength)
        {
            throw new Exception("There was an error creating the hash");
        }
    
        string hex = CryptographicBuffer.EncodeToHexString(buffHash);
    
        return hex;
    }
    
    public string Encrypt(string input, string pass)
    {
        SymmetricKeyAlgorithmProvider provider = SymmetricKeyAlgorithmProvider.OpenAlgorithm(SymmetricAlgorithmNames.AesEcb);
        CryptographicKey key;
    
        string encrypted = "";
    
        byte[] keyhash = Encoding.ASCII.GetBytes(GetMD5Hash(pass));
        key = provider.CreateSymmetricKey(CryptographicBuffer.CreateFromByteArray(keyhash));
    
        IBuffer data = CryptographicBuffer.CreateFromByteArray(Encoding.Unicode.GetBytes(input));
        var a = CryptographicEngine.Encrypt(key, data, null);
        encrypted = CryptographicBuffer.EncodeToBase64String(a);
    
        return encrypted;
    }
    
    public string Decrypt(string input, string pass)
    {
        var keyHash = Encoding.ASCII.GetBytes(GetMD5Hash(pass));
    
        // Create a buffer that contains the encoded message to be decrypted.
        IBuffer toDecryptBuffer = CryptographicBuffer.DecodeFromBase64String(input);
    
        // Open a symmetric algorithm provider for the specified algorithm.
        SymmetricKeyAlgorithmProvider aes = SymmetricKeyAlgorithmProvider.OpenAlgorithm(SymmetricAlgorithmNames.AesEcb);
    
        // Create a symmetric key.
        var symetricKey = aes.CreateSymmetricKey(keyHash.AsBuffer());
    
        var buffDecrypted = CryptographicEngine.Decrypt(symetricKey, toDecryptBuffer, null);
    
        string strDecrypted = CryptographicBuffer.ConvertBinaryToString(BinaryStringEncoding.Utf8, buffDecrypted);
    
        return strDecrypted;
    }
