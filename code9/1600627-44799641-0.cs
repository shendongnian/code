    public static class StringExt
    {
        public static string AlphabeticChars(this string self)
        {
            var alphabeticChars = self.Select(char.ToLower).Where(c => 'a' <= c && c <= 'z');
            return new string(alphabeticChars.ToArray());
        }
    }
