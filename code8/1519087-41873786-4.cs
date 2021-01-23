    public static class DictionaryExtensions
    {
        public static IDictionary<TKey, List<TValue>> Merge<TKey, TValue>(
            this IDictionary<TKey, TValue> me,
            IDictionary<TKey, TValue> other
        )
        {
            var keys = me.Concat(other)
                .GroupBy(x => x.Key)
                .ToDictionary(
                    x => x.Key,
                    x => x.Select(z => z.Value).ToList()
                );
            return keys;
        }
    }
