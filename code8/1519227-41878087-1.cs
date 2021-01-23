    public static class StringExtensions
    {
        public static string SelectOnlyVowels(this string text)
        {
            var vowels = "aeiou";
            return new String(text.Where(p => vowels.IndexOf(p.ToString(), StringComparison.InvariantCultureIgnoreCase) >= 0).ToArray());
        }
    }
