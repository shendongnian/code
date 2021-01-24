    public static string ToKebabCase(this string value)
    {
        if (string.IsNullOrEmpty(value))
            return value;
    
        Regex r1 = new Regex(@"({[^}]+})(\/[A-Z][a-z]+)([A-Z][a-z]+\/)({[^}]+})");
        Match match = r1.Match(value);
        if (match.Success) {
            string v1 = match.Groups[1].Value;
            string v2 = match.Groups[2].Value;
            string v3 = match.Groups[3].Value;
            string v4 = match.Groups[4].Value;
            value = v1 + v2.ToLower() + "-" + v3.ToLower() + v4;            
        }
        return value;
    }
