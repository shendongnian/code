    public class TripleKeyedDictionary<TKey1, TKey2, TKey3, TValue> : Dictionary<Tuple<TKey1, TKey2, TKey3>, TValue>
    {
        public TValue this [TKey1 key1, TKey2 key2, TKey3 key3]
        {
            get { return this[Tuple.Create(key1, key2, key3)]; }
            set { this[Tuple.Create(key1, key2, key3)] = value; }
        }
    }
