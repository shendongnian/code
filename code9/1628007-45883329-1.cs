    private void HashPassword(string password, out string passwordHash, ref string passwordSalt)
        {
            byte[] passwordBytes = Encoding.Unicode.GetBytes(password);
            byte[] saltBytes = null;
            if (!string.IsNullOrEmpty(passwordSalt))
            {
                saltBytes = Convert.FromBase64String(passwordSalt);
            }
            else
            {
                saltBytes = new byte[128 / 8];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(saltBytes);
                }
            }
            byte[] totalBytes = new byte[saltBytes.Length + passwordBytes.Length];
            Buffer.BlockCopy(saltBytes, 0, totalBytes, 0, saltBytes.Length);
            Buffer.BlockCopy(passwordBytes, 0, totalBytes, saltBytes.Length, passwordBytes.Length);
            using (SHA1 hashAlgorithm = SHA1.Create())
            {
                passwordHash = Convert.ToBase64String(hashAlgorithm.ComputeHash(totalBytes));
            }
            passwordSalt = Convert.ToBase64String(saltBytes);
        }
