    public static string Encrypt(string key, string toEncrypt)
    {
        var keyArray = Convert.FromBase64String(key);
        var info = Encoding.ASCII.GetBytes(toEncrypt);
        var encrypted = Encrypt(keyArray, info);
        return Convert.ToBase64String(encrypted);
    }
    public static string Decrypt(string key, string cipherString)
    {
        var keyArray = Convert.FromBase64String(key);
        var cipherText = Convert.FromBase64String(cipherString);
        var decrypted = Decrypt(keyArray, cipherText);
        return Encoding.ASCII.GetString(decrypted);
    }
