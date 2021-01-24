    public static class DictionaryExtensions
    {
        public static TValue GetOrCreate<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key) where TValue : new()
        {
            var exists = dictionary.TryGetValue(key, out var value);
            dictionary.Add(key, value);
            
            return exists ? value : new TValue();
        }
    }
