    public static String HashPassword(String password)
    {
        Byte[] salt = new Byte[24];
 
        RNGCryptoServiceProvider cryptoProvider = new RNGCryptoServiceProvider();
        cryptoProvider.GetBytes(salt);
        Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt, 1000);
        
        return Convert.ToBase64String(pbkdf2.GetBytes(20)); // Size of PBKDF2-HMAC-SHA-1 Hash 
    }
