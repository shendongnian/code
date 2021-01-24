    public static class DictionaryExtensions
    {
        public static U TryGetValueOrDefault<T, U>(this IDictionary<T, U> dict, T key, U defaultValue)
        {
            U temp;
            if (dict.TryGetValue(key, out temp))
                return temp;
            return defaultValue;
        }
    }
