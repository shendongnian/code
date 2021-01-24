        public static string PregReplace(string pattern, string newValue, string src)
        {
            Regex rg = new Regex(pattern);
            MatchCollection mc = rg.Matches(src);
            foreach (var match in mc)
            {
                src = src.Replace(match.ToString(), newValue);
            }
            return src;
        }
