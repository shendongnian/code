    public String GenerateToken(TokenContent data)
    {
        byte[] data;
        using(var ms = new MemoryStream())
        {
            Serializer.Serialize(ms, cust);
            data = ms.ToArray();
        }
        var encryptedData = MachineKey.Protect(data, "TokenDataUrl");
        var token = Convert.ToBase64String(encryptedData);
        return token;
    }
    
    public TokenContent ReadToken(string token)
    {
        byte[] encryptedData = Convert.FromBase64String(token);
        var data = MachineKey.Unprotect(encryptedData , "TokenDataUrl");
        TokenContent content;
        using(var ms = new MemoryStream(data))
        {
            content = Serializer.Deserialize<TokenContent>(ms);
        }
        return content;
    }
