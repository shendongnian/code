    public static string ParseTelephoneNumber(string rawInput)
    {
        var pattern = "tel:(.*?);ext=\\d+";
        var match = Regex.Match(rawInput, pattern);
        return match.Groups[1].Value;
    }
    
    public static string ParseExtension(string rawInput)
    {
        var pattern = "tel:.*?;ext=(\\d+)";
        var match = Regex.Match(rawInput, pattern);
        return match.Groups[1].Value;
    }
