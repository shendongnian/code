    public static class StringExt
    {
        public static string Left(this string self, int count)
        {
            string result = self.Length <= count 
                ? self 
                : self.Substring(0, count);
            return result;
        }
    }
