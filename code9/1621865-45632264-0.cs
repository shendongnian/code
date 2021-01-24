        bool  IsValid(string line)
        {
            if (string.IsNullOrEmpty(line)) return true;
            return !line.Trim().EndsWith(",");
        }
------------------------
        IEnumerable<string> GetTokens(string line)
        {
            var pattern = @"(AB\d{7}([,;]|[^0-9a-zA-Z]|$))";
            var matches = Regex.Matches(line, pattern, RegexOptions.Singleline);
            foreach (Match match in matches)
            {
                yield return match.Value;
            }
        }
