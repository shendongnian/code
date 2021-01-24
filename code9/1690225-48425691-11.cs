    public static class DictionaryExtensions
    {
        public static TValue AddOrUpdate<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            TKey key,
            TValue addValue,
            Func<TKey, TValue, TValue> updateCallback)
        {
            if (dictionary == null)
                throw new ArgumentNullException(nameof(dictionary));
            if (updateCallback == null)
                throw new ArgumentNullException(nameof(updateCallback));
            if (dictionary.TryGetValue(key, out var value))
                value = updateCallback(key, value);
            else
                value = addValue;
            dictionary[key] = value;
            return value;
        }
    }
