    public static class TextExtensions
    {
        public static string Reencode(this string s, Encoding toEncoding, Encoding fromEncoding)
        {
            return toEncoding.GetString(fromEncoding.GetBytes(s));
        }
    }
