    public static class DictionaryExtensions
    {
        public static TValue GetOrCreate<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue = null) where TValue : class, new()
        {
            var exists = dictionary.TryGetValue(key, out var value);
           
            if (!exists)
            {
                value = defaultValue ?? new TValue();
                dictionary.Add(key, value);
            }
            
            return value;
        }
    }
