    private IEnumerable<string> GetMatchingKeys(
        Dictionary<string, List<int>> dictionary, string key)
    {
        // TODO: Use TryGetValue if key might not be in dictionary
        HashSet<int> elements = new HashSet<int>(dictionary[key]);
        return dictionary.Where(pair => pair.Value.Any(x => elements.Contains(x)))
                         .Select(pair => pair.Key);
    }
