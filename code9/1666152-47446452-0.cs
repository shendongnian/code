    public static string[] DetailExtractor1(string input)
    {
        var match = Regex.Match(input, @"^(?<name>\w+\s+\w+)\s+(?<num>\+\d+)\r\n(?<type>\w+)");
        if (match.Success)
        {
            return new string[] {
                match.Groups["name"].Value,
                match.Groups["num"].Value,
                match.Groups["type"].Value
            };
        }
        return null;
    }
