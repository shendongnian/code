    public static string ToKebabCase(this string value)
    {
        if (string.IsNullOrEmpty(value))
            return value;
    
        Regex r1 = new Regex(@"({[^}]+})(\/[A-Z][a-z]+)([A-Z][a-z]+\/)({[^}]+})");
        Match match = r1.Match(value);
        if (match.Success) {
            value = String.Format("{0}{1}-{2}{3}", 
                match.Groups[1].Value,
                match.Groups[2].Value.ToLower(),
                match.Groups[3].Value.ToLower(),
                match.Groups[4].Value
            );           
        }
        return value;
    }
