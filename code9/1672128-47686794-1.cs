    public static String GetHash(String text, String key)
    {
        ASCIIEncoding encoding = new ASCIIEncoding();
        Byte[] textBytes = encoding.GetBytes(text);
        Byte[] keyBytes = encoding.GetBytes(key);
        HMACSHA256 hash = new HMACSHA256(keyBytes);
        Byte[] hashBytes = hash.ComputeHash(textBytes);
        return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
    }
