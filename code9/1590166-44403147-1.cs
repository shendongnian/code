    public class SnapshotDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        private readonly Dictionary<TKey, TValue> _dictionary = new Dictionary<TKey, TValue>();
        private readonly object _lock = new object();
        public void Add(TKey key, TValue value)
        {
            lock (_lock)
            {
                _dictionary.Add(key, value);
            }
        }
        // TODO: Other necessary IDictionary methods
        public Dictionary<TKey, TValue> GetSnaphot()
        {
            lock (_lock)
            {
                return new Dictionary<TKey, TValue>(_dictionary);
            }
        }
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return GetSnaphot().GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
