    public static Tuple<string, string> ParseTelephoneAndExtension(string rawInput)
    {
        var match = Regex.Match(rawInput, @"tel:(\+\d+);ext=(\d+)");
        if (match.Success)
        {
            return new Tuple<string, string>(match.Groups[1].Value, match.Groups[2].Value);
        }
        return new Tuple<string, string>(null, null);
    }
