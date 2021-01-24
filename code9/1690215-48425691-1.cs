    public static class DictionaryExtensions
    {
        public static TValue GetOrAdd<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            TKey key,
            Func<TKey, TValue> addCallback)
        {
            if (dictionary == null)
                throw new ArgumentNullException(nameof(dictionary));
            if (addCallback == null)
                throw new ArgumentNullException(nameof(addCallback));
            if (dictionary.TryGetValue(key, out var value))
                return value;
            value = addCallback(key);
            dictionary[key] = value;
            return value;
        }
    }
