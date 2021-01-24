    var result = new Dictionary<string, string[]>();
    var searchInLines = new string[200]; // filled with resumes 
    var dictionary = new string[50000]; // search dictionary
    searchInLines.AsParallel()
        .WithDegreeOfParallelism(Environment.ProcessorCount * 2)
        .Select(searchInLine =>
            {
                result.Add(searchInLine, dictionary.Where(s => searchInLine.Contains(s)).ToArray());
                return string.Empty;
            })
        .ToList();
