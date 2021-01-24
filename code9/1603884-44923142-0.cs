    public List<string> AddName(IEnumerable<string> list, string name)
    {
    var suffixSelector = new Regex("^(?<name>[A-Za-z]+)(?<suffix>\\d?)$",
       RegexOptions.Singleline);
    var namesMap = list.Select(n => suffixSelector.Match(n))
        .Select(x => new {name = x.Groups["name"].Value, suffix = x.Groups["suffix"].Value})
        .GroupBy(x => x.name)
        .ToDictionary(x => x.Key, x => x.Count());
    if (namesMap.ContainsKey(name))
        namesMap[name] = namesMap[name] + 1;
    return namesMap.Select(x => x.Key).Concat(
        namesMap.Where(x => x.Value > 1)
            .SelectMany(x => Enumerable.Range(2, x.Value - 1)
            .Select(i => $"{x.Key}{i}"))).ToList();
    }
