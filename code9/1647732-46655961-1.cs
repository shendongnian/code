    public static class DictionaryExtensions
    {
        public static TValue UpdateAndGet<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue newVal)
        {
            TValue oldVal;
            if (!dictionary.TryGetValue(key, out oldVal))
            {
                oldVal = default(TValue);
            }
            dictionary[key] = newVal;
            return oldVal;
        }
    }
