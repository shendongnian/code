    public static string ToKebabCase(this string value)
    {
        if (string.IsNullOrEmpty(value))
            return value;
    
        return Regex.Replace(
                value,
                @"(\/[A-Z][a-z]+)([A-Z][a-z]+\/)",
                "$1-$2",
                RegexOptions.Compiled)
            .Trim()
            .ToLower();
    }
