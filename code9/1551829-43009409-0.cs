    public static class DictionaryExtensions
    {
        public static void SetValue<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            if (value == null && dictionary.ContainsKey(key))
            {
                dictionary.Remove(key);
            }
            else
            {
                dictionary[key] = value;
            }
        }
        public static TValue GetValue<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
        {
            if (dictionary.ContainsKey(key))
            {
                return dictionary[key];
            }
            return default(TValue);
        }
    }
