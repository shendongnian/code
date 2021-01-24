    foreach (var entry in groupStems)
    {
        var grStems = entry.Value;
        var grKeywords = (from kw in Keywords
                                              where grStems.All(keywordStems[kw].Contains)
                                              select kw).ToArray();
        if (grKeywords.Length >= Settings.MinCount)
        {
            Sets.Add(entry.Key, new HashSet<string>(grKeywords));
        }
    }
