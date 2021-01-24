        public static string GenerateHash(string password, string salt)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] src = Convert.FromBase64String(salt);
            byte[] dst = new byte[src.Length + bytes.Length];
            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);
            var provider = new HMACSHA1(src);
            provider.Initialize();
            byte[] inArray = provider.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }
