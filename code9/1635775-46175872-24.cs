    public interface IIndex<TKey, TValue>
    {
        bool TryGetValue(TKey key, out TValue value);
        TValue this[TKey key] { get; set; }
    }
