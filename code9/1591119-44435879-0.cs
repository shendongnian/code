        public static string RandomString(int len)
        {
            var array = Enumerable.Range(char.MinValue, char.MaxValue - char.MinValue + 1).Select(x => (char)x).ToArray();
            return RandomString(len, array);
        }
        private static string RandomString(int len, char[] array)
        {
            Random r = new Random();
            StringBuilder sb = new StringBuilder();
            while (sb.Length < len)
                sb.Append(array[r.Next(array.Length-1)]);
            return sb.ToString();
        }
