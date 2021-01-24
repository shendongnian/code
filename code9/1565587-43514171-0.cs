    public static class DictionaryExtensions
    {
        public static TValue GetOrCreate<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key) where TValue : new() =>
            dictionary.TryGetValue(key, out var value) ? value : new TValue();
    }
