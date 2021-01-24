    public static string GenerateKeyHash(string Password)
    {
        if (string.IsNullOrEmpty(Password)) return null;
        if (Password.Length < 1) return null;
        byte[] salt = new byte[20];
        byte[] key = new byte[20];
        byte[] ret = new byte[40];
        try
        {
            using (RNGCryptoServiceProvider randomBytes = new RNGCryptoServiceProvider())
            {
                randomBytes.GetBytes(salt);
                using (var hashBytes = new Rfc2898DeriveBytes(Password, salt, 10000))
                {
                    key = hashBytes.GetBytes(20);
                    Buffer.BlockCopy(salt, 0, ret, 0, 20);
                    Buffer.BlockCopy(key, 0, ret, 20, 20);
                }
            }
            // returns salt/key pair
            return Convert.ToBase64String(ret);
        }
        finally
        {
            if (salt != null)
                Array.Clear(salt, 0, salt.Length);
            if (key != null)
                Array.Clear(key, 0, key.Length);
            if (ret != null)
                Array.Clear(ret, 0, ret.Length);
        } 
    }
