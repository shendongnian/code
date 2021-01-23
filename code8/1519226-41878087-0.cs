    public static class StringExtensions
    {
        public static string SelectOnlyVowels(this string text)
        {
            var vowels = "aeiou";
            return new String(text.ToLower().Where(p => vowels.Contains(p)).ToArray());
        }
    }
