    var mergeResults = fileResults.Concat(extractorResults)
                        .GroupBy(kvp => kvp.Key)
                        .ToDictionary(g => g.Key, g => g.SelectMany(kvp => kvp.Value).ToList())
                        .Where(kvp => !fileResults.ContainsKey(kvp.Key));
    
                    var kvpMergeResults = mergeResults as IList<KeyValuePair<string, List<Result>>> ?? mergeResults.ToList();
                    fileResults.Add(kvpMergeResults.First().Key, kvpMergeResults.First().Value);
