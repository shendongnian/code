    public static class StringExtensions
    {
        public static string Prefix(this string value, int length)
        {
            if (value.Length > length)
            {
                return value;
            }
            return value.SubString(0, length);
        }
    }
