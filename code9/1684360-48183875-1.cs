    private static void UsingRegex(string input)
    {
        Dictionary<string, string> namedFields = new Dictionary<string, string>();
        List<string> anyField = new List<string>();
        Regex regex = new Regex("(?:(?<key>[^ ]+):(?<value>[^ ]+))|(?<loneValue>[^ ]+)", RegexOptions.Compiled);
        foreach (Match match in regex.Matches(input))
        {
            string key = match.Groups["key"].Value,
                value = match.Groups["value"].Value,
                loneValue = match.Groups["loneValue"].Value;
            if (!string.IsNullOrEmpty(key))
            {
                namedFields.Add(key, value);
            }
            else
            {
                anyField.Add(loneValue);
            }
        }
    }
