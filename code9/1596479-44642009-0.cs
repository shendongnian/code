    public static class StringExtensions
    {
        public static bool Contains(this string self, string text)
            => self.IndexOf(text) >= 0;
    }
