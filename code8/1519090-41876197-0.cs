        Dictionary<string, object> MergeDictionary(IEnumerable<Dictionary<string, object>> dicts)
        {
            var l = dicts.SelectMany(d => d).ToLookup(kv => kv.Key, kv => kv.Value);
            return l.ToDictionary(
                g => g.Key,
                g => g.Count() == 1
                    ? g.First()
                    : MergeDictionary(g.Cast<Dictionary<string, object>>()));
        }
