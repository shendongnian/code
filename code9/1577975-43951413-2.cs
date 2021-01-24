    public static class StringExtensions
    {
        public static string ProgressiveReplace(this string source, Dictionary<char, char> replacements)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in source)
            {
                char replacement = c;
                if (replacements.ContainsKey(c))
                    replacement = replacements[c];
                sb.Append(replacement, 1);
            }
            return sb.ToString();
        }
    }
