    public static IDictionary<TKey, List<TValue>> Merge<TKey, TValue>(this IDictionary<TKey, List<TValue>> me, IDictionary<TKey, List<TValue>> other)
    {
        var keys = me.Concat(other)
            .GroupBy(x => x.Key)
            .ToDictionary(
                x => x.Key,
                x => x.SelectMany(z => z.Value).ToList()
            );
        return keys;
    }
    public static IDictionary<TKey, List<TValue>> Merge<TKey, TValue>(this IDictionary<TKey, List<TValue>> me, IDictionary<TKey, TValue> other)
    {
        return me
            .Merge(
                other
                    .ToDictionary(
                        x => x.Key,
                        x => new List<TValue> { x.Value }
                    )
            );
    }
