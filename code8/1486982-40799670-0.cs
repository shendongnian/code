    static char[] GetMostFrequentChar(string str)
    {
        Dictionary<char, int> result = str.GroupBy(x => x)
                                            .ToDictionary(x => x.Key, x => x.Count());
        return result.Where(x => x.Value == result.Values.Max())
                        .Select(x => x.Key).ToArray();
    }
