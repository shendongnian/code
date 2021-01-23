    static void Main(string[] args)
    {
        Dictionary<Blopp, List<double>> data = CreateData();
        List<Dictionary<Blopp, double>> result = PiviotDictionary(data).ToList();
    }
    private static IEnumerable<Dictionary<TKey, TValue>> GetSingleEntires<TKey,TValue>(Dictionary<TKey, List<TValue>> data)
    {
        bool foundValue = true;
        for(int i = 0; foundValue == true; i++)
        {
            foundValue = false;
            var result = new Dictionary<TKey, TValue>();
            foreach (var kvp in data)
            {
                if (kvp.Value.Count > i)
                {
                    foundValue = true;
                    result.Add(kvp.Key, kvp.Value[i]);
                }
            }
            if (foundValue)
                yield return result;
        }
    }
