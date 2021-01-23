	public static class StringExtensions
    {
        public static string Replace(this string original, char replacement, params char[] replaceables)
        {
            StringBuilder builder = new StringBuilder(original.Length);
            HashSet<Char> replaceable = new HashSet<char>(replaceables);
            foreach (Char character in original)
            {
                if (replaceable.Contains(character))
                    builder.Append(replacement);
                else
                    builder.Append(character);
            }
            return builder.ToString();
        }
        public static string Replace(this string original, char replacement, string replaceables)
        {
            return Replace(original, replacement, replaceables.ToCharArray());
        }
    }
