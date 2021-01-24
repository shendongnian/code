    public static class StringExtensions
    {
        public static string ReplaceMultiple(this string source, Dictionary<char, char> replacements)
        {
            return string.Join(string.Empty , source.Select(x=>Replace(x,replacements)));
        }
        private static char Replace(char arg, Dictionary<char, char> replacements)
        {
            if(replacements.ContainsKey(arg))
                arg = replacements[arg];
            return arg;
        }
    }
