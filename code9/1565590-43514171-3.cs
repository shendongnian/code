    public static class DictionaryExtensions
    {
        public static TValue GetOrCreate<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key) where TValue : new()
        {
            var exists = dictionary.TryGetValue(key, out var value);
            
            if (!exists)
            {
                value = new TValue();
                dictionary.Add(key, value);
            }
            
            return value;
        }
    }
