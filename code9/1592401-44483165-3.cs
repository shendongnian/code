     public static bool ComparePasswords(string PasswordHash, string Password)
    {
        if (string.IsNullOrEmpty(PasswordHash) || string.IsNullOrEmpty(Password)) return false;
        if (PasswordHash.Length < 40 || Password.Length < 1) return false;
        byte[] salt = new byte[20];
        byte[] key = new byte[20];
        byte[] hash = Convert.FromBase64String(PasswordHash);
        try
        {
            Buffer.BlockCopy(hash, 0, salt, 0, 20);
            Buffer.BlockCopy(hash, 20, key, 0, 20);
            using (var hashBytes = new Rfc2898DeriveBytes(Password, salt, 10000))
            {
                byte[] newKey = hashBytes.GetBytes(20);
                if (newKey != null)
                    if (newKey.SequenceEqual(key))
                        return true;
            }
            return false;
        }
        finally
        {
            if (salt != null)
                Array.Clear(salt, 0, salt.Length);
            if (key != null)
                Array.Clear(key, 0, key.Length);
            if (hash != null)
                Array.Clear(hash, 0, hash.Length);
        }
    }
