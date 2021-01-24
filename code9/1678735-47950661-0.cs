    public static Regex WildcardToRegex(string pattern)
    {
        return new Regex("^" + Regex.Escape(pattern)
            .Replace("\\*", ".*")
            .Replace("\\?", ".") + "$");
    }
