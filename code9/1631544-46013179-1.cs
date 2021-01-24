        public static string GenerateSalt()
        {
            var buf = new byte[16];
            RandomNumberGenerator.Create().GetBytes(buf);
            return Convert.ToBase64String(buf);
        }
        public static string GenerateHash(string password, string salt)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(password); //TODO: consider removing it
            byte[] src = Convert.FromBase64String(salt);
            byte[] dst = new byte[src.Length + bytes.Length];
            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);
            var provider = new Rfc2898DeriveBytes(password, src, 1000);
            byte[] inArray = provider.GetBytes(20/*bytes like in SHA-1*/);
            return Convert.ToBase64String(inArray);
        }
