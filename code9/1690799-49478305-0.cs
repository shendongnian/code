    public static string NormalizeName(string name)
    {
        if (name == null)
           return null;
        var trimSpacesRegex = new Regex("\\s+", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        return trimSpacesRegex.Replace(name, " ").Replace('&', '＆').Replace('"', '＂');
    }
