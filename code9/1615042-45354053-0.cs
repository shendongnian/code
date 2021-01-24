    public static byte[] CreateToken(string message, string secret)
    {
        string base64Message = Convert.ToBase64String(messageBytes);
        using (var hmacsha256 = new HMACSHA256(keyByte))
        {
            byte[] hashmessage = hmacsha256.ComputeHash(base64Bytes);
            return hashmessage;
        }
    }
