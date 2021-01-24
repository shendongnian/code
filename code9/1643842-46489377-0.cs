    public string GenerateSignature(string key, string content)
    {
        var hmac = new System.Security.Cryptography.HMACSHA1();
        hmac.Key = Encoding.UTF8.GetBytes(key);
        var contentBytes = Encoding.UTF8.GetBytes(content);
        var signature = hmac.ComputeHash(contentBytes);
        return Convert.ToBase64String(signature);
    }
