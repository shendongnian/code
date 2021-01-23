        // generated all possible text truncation patterns
        private static readonly List<Regex> FirstWordRegexes = new List<Regex>
        {
            new Regex(@"^\W*\w+(?:\W+\w+){0}", RegexOptions.Compiled),
            new Regex(@"^\W*\w+(?:\W+\w+){1}", RegexOptions.Compiled),
            new Regex(@"^\W*\w+(?:\W+\w+){2}", RegexOptions.Compiled),
            new Regex(@"^\W*\w+(?:\W+\w+){3}", RegexOptions.Compiled),
            new Regex(@"^\W*\w+(?:\W+\w+){4}", RegexOptions.Compiled),
            new Regex(@"^\W*\w+(?:\W+\w+){5}", RegexOptions.Compiled),
            new Regex(@"^\W*\w+(?:\W+\w+){6}", RegexOptions.Compiled),
            // ...
            // removed for brevity
            // ...
            new Regex(@"^\W*\w+(?:\W+\w+){147}", RegexOptions.Compiled),
            new Regex(@"^\W*\w+(?:\W+\w+){148}", RegexOptions.Compiled),
            new Regex(@"^\W*\w+(?:\W+\w+){149}", RegexOptions.Compiled),
        };
        public static string GetFirstWordsRegExOptimized(string s, int wordCount, string truncateSuffix = " [...]")
        {
            var regex = FirstWordRegexes[wordCount-1];
            var match = regex.Match(s);
            if (!match.Success)
                return s;
            var ret = match.Value;
            return ret.Length < s.Length ? ret + truncateSuffix : ret;
        }
