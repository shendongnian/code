    public static Dictionary<string, List<int>> _dictionary;
    public static void CacheIndexes()
    {
        _dictionary = cpaths.Select((x, i) => new { index = i, value = x })
                            .GroupBy(x => x.value.src)
                            .ToDictionary(x => x.Key, x => x.Select(a => a.index).ToList());
    }
