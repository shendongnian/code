    foreach (var entry in groupStems)
    {
        var grStems = entry.Value;
        var grKeywords = (WHATEVER).ToArray();
        if (grKeywords.Length >= Settings.MinCount)
            Sets.Add(entry.Key, new HashSet<string>(grKeywords));
    }
