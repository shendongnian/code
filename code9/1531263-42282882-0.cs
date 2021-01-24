    public interface ItemWithKey<TKey>
    {
        TKey Key { get; }
    }
    public static void AddByKey<TKey, T>(this Dictionary<TKey, T> dictionary, T item)
        where T : ItemWithKey<TKey>
    {
        dictionary.Add(item.Key, item);
    }
