        private T2 CacheIt<T2>(Func<T2> func, object input)
        {
            var key = CreateMD5(JsonConvert.SerializeObject(input));
            var cache = MemoryCache.Default;
            var value = cache.Get(key);
            if (value != null)
            {
                return (T2)value;
            }
            value = func();
            var policy = new CacheItemPolicy { SlidingExpiration = new TimeSpan(1, 0, 0) };
            cache.Add(key, value, policy);
            return (T2)value;
        }
        private string CreateMD5(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
