    public static class DictionaryExtensions
    {
        public static IDictionary<TKey, TValue> ExceptKeys<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, params TKey[] keys)
        {
            if (dictionary == null) throw new ArgumentNullException(nameof(dictionary));
            if (keys == null) throw new ArgumentNullException(nameof(keys));
            return dictionary.Where(e => !keys.Contains(e.Key)).ToDictionary(e => e.Key, e => e.Value);
        }
        public static IDictionary<TKey, TValue> ExceptValues<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, params TValue[] values)
        {
            if (dictionary == null) throw new ArgumentNullException(nameof(dictionary));
            if (values == null) throw new ArgumentNullException(nameof(values));
            return dictionary.Where(e => !values.Contains(e.Value)).ToDictionary(e => e.Key, e => e.Value);
        }
    }
