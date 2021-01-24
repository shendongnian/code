    public static class QueryHelper
    {
        public static bool Like(this string target, string pattern)
        {
            return WildcardToRegex(pattern).IsMatch(target);
        }
        public static Regex WildcardToRegex(string pattern)
        {
            ...  (same code from above)  ...
        }
    }
