    RSAParameters param;
    try{
        var json = File.ReadAllText(paramFile);
        param = JsonConvert.DeserializeObject<RSAParameters>(json);
    }catch(Exception _)
    {
        param = new RSACryptoServiceProvider(2048).ExportParameters(true);
        var jsonString = JsonConvert.SerializeObject(param);
        File.WriteAllText(paramFile, jsonString);
    }
    var securityKey = new RsaSecurityKey(param);
