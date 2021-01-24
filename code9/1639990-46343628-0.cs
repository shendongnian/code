    foreach (string gr in groupStems.Keys)
    {
        var grStems = groupStems[gr];
        var grKeywords = new HashSet<string>((from kw in Keywords
                                                where grStems.All(keywordStems[kw].Contains)
                                                select kw));
        if (grKeywords.Count >= Settings.MinCount)
        {
            Sets.Add(gr, grKeywords);
        }
    }
