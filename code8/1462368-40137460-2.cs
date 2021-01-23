    public class ThreadSafeSortedDictionary<TKey, TValue>
    {
        private readonly SortedDictionary<TKey, TValue> _dict;
        private readonly object _sync;
        public ReadOnlyDictionary<TKey, TValue> ReadOnly { get; private set; }
        public IEnumerable<TValue> Values
        {
            get { return ReadOnly.Values; }
        }
        public IEnumerable<TKey> Keys
        {
            get { return ReadOnly.Keys; }
        }
        public int Count
        {
            get { return ReadOnly.Count; }
        }
        public ThreadSafeSortedDictionary(IComparer<TKey> comparer)
        {
            _dict = new SortedDictionary<TKey, TValue>(comparer);
            _sync = new object();
        }
        public void Add(TKey key, TValue value)
        {
            lock (_sync)
            {
                _dict.Add(key, value);
                SetReadOnlyDictionary();
            }
        }
        public void AddRange(IEnumerable<KeyValuePair<TKey, TValue>> keyValues)
        {
            if (keyValues == null) return;
            InternalAddRange(keyValues);
        }
        public void Remove(TKey key)
        {
            lock (_sync)
            {
                _dict.Remove(key);
                SetReadOnlyDictionary();
            }
        }
        public void Replace(IEnumerable<KeyValuePair<TKey, TValue>> newKeyValues)
        {
            //Throw exception, because otherwise we'll end up clearing the dictionary
            if (newKeyValues == null) throw new ArgumentNullException("newKeyValues");
            InternalAddRange(newKeyValues, true);
        }
        private void InternalAddRange(IEnumerable<KeyValuePair<TKey, TValue>> keyValues, bool clearBeforeAdding = false)
        {
            lock (_sync)
            {
                if (clearBeforeAdding) _dict.Clear();
                foreach (var kvp in keyValues)
                {
                    _dict.Add(kvp.Key, kvp.Value);
                }
                SetReadOnlyDictionary();
            }
        }
        private void SetReadOnlyDictionary()
        {
            lock (_sync)
            {
                ReadOnly = new DictionaryReadOnly<TKey, TValue>(new SortedList<TKey, TValue>(_dict, _dict.Comparer));
            }
        }
    }
