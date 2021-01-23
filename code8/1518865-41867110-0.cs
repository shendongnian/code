    public static decimal Parse(string s)
    {
        if (string.IsNullOrEmpty(s))
            throw new ArgumentNullException("s is null");
        var match = Regex.Match(s, "[A-Z]{3}");
        if (!match.Success)
            throw new FormatException("s is not in the correct format. Currency code is not found.");
        s = s.Replace(match.Value, string.Empty); // I don't like this line
        decimal value = decimal.Parse(s, NumberStyles.Currency);
        return value;
    }
