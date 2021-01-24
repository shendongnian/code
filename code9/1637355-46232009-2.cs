        var mainDict = new Dictionary<string, Dictionary<string, List<string>>>()
    {
        {"Group1", new Dictionary<string, List<string>>{{"A", new List<string> {"bob", "steve", "greg"}}}},
        {"Group2", new Dictionary<string, List<string>>{{"B", new List<string> {"tom", "thomas", "justin", "lee"}}}},
        {"Group3", new Dictionary<string, List<string>>{ { "C", new List<string> { "dustin", "rick" }}}}
    };
    
    var result = mainDict.Select(x => x.Value.Where(y => y.Key == "A")).First().First().Value;
