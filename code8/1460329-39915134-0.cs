    public static class DictionaryExt
    {
        public static void RemoveAll<K, V>(this IDictionary<K, V> dict, Func<K, V, bool> predicate)
        {
            foreach (var key in dict.Keys.ToArray().Where(key => predicate(key, dict[key])))
                dict.Remove(key);
        }
    }
