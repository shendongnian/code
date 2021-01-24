    private static bool Match(string pattern, string stringToCheck)
        {
            var finalPattern = pattern.Replace("*", ".*?");
            Regex regex = new Regex(finalPattern);
            return regex.IsMatch(stringToCheck);
        }
