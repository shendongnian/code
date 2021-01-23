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
    
