    string MostCommon = names.GroupBy(v => v)
        .OrderByDescending(g => g.Count())
        .First()
        .Key;
    int count = names.Where(x => x == MostCommon).Count();
    var mostCommonList = = names.GroupBy(v => v)
        .Where(g => g.Count() >= count)
        .Key;
