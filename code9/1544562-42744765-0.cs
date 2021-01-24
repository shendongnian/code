    public static class RegexStringExtension
    {
        public static String RegexReplace ( this String haystack, String regex, String replacement )
        {
            return new Regex ( regex ).Replace ( haystack, replacement );
        }
    }
