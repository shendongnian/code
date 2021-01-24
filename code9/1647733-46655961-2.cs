    public static class DictionaryExtensions
    {
        public static TValue UpdateAndGet<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue newVal)
        {
            TValue oldVal;
            dictionary.TryGetValue(key, out oldVal);
            dictionary[key] = newVal;
            return oldVal;
        }
    }
