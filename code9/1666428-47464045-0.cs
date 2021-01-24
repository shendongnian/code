    public static string FindBestValidRegex(string input, string pattern)
    {
        var lastMatch = "";
        for (int i = 0; i < pattern.Length; i++)
        {
            try
            {
                var partialPattern = pattern.Substring(0, i + 1);
                var regex = new Regex(partialPattern);
                if (regex.IsMatch(input))
                {
                    lastMatch = partialPattern;
                }
            }
            catch { }
        }
        return lastMatch;
    }
