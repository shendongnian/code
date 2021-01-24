    public static GetMostFrequentCharacter(string value)
    {
        return value
            .GroupBy(o => o)
            .OrderByDescending(o => o.Count())
            .First()
            .Key
            .ToString()
    }
