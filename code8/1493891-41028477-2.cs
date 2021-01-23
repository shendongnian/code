    private static Dictionary<char, HashSet<string>> buildDictionary(IEnumerable<string> words)
    {
        var dictionary = new Dictionary<char, HashSet<string>>();
        foreach (var word in words)
        {
            var key = word[0];
            if (!dictionary.ContainsKey(key))
            {
                dictionary[key] = new HashSet<string>();
            }
            dictionary[key].Add(word);
        }
        return dictionary;
    }
