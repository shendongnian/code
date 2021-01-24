        public string GetSHAControlName(string userInput)
        {
            using (var sha = SHA1.Create())
            {
                var input = Encoding.Default.GetBytes(userInput);
                var hash = sha.ComputeHash(input);
                
                return string.Concat("uc", GetStringFromHash(hash));
            }
        }
        public static string GetStringFromHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString();
        }
