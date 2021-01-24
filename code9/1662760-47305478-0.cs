    public static class StringExtensions
    {
        public static string SafeFormat(this string value, params object[] args)
        {
            var pattern = @"{(.*?)}";
            var matches = Regex.Matches(value, pattern);
            var matchCount = matches.Count;
            if (matchCount > args.Length)
            {
                var argsExtended = args.ToList();
                for (int i = args.Length; i < matchCount; i++)
                {
                    argsExtended.Add($"{{{i}}}"); //Can add null value to erase them
                }
                return string.Format(value, argsExtended.ToArray());
            }
            return string.Format(value, args);
        }
    }
