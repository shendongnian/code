    public class ThreadSafeSortedDict<TKey, TValue>
    {
        private readonly SortedDictionary<TKey, TValue> _dict;
        private IReadOnlyDictionary<TKey, TValue> _readOnly;
        private readonly object _lock = new object();
    
        public IReadOnlyDictionary<TKey, TValue> ReadOnly
        {
            get
            {
                lock (_lock)
                {
                    if (_readOnly == null)
                    {
                      // NOTE: SortedList is faster when populating from already-sorted data
                        _readOnly = new ReadOnlyDictionary(new SortedList(_dict));
                    }
                }
                return _readOnly;
            }
        }
    
        public ThreadSafeSortedDict(IComparer<TKey> comparer)
        {
            _dict = new SortedDictionary<TKey, TValue>(comparer);
        }
    
        public void Add(TKey key, TValue value)
        {
            lock (_lock)
            {
                _dict.Add(key,value);
                _readOnly = null;
            }
        }
    
        public void AddRange(IEnumerable<KeyValuePair<TKey,TValue>> keyValues)
        {
            if (keyValues == null) return;
            lock (_lock)
            {
                foreach (var keyValue in keyValues)
                {
                    Add(keyValue.Key, keyValue.Value);
                }
                _readOnly = null;
            }
        }
    
        public void Remove(TKey key)
        {
            lock (_lock)
            {
                _dict.Remove(key);
                _readOnly = null;
            }
        }
    
        public void Replace(IEnumerable<KeyValuePair<TKey, TValue>> newKeyValues)
        {
            if (newKeyValues == null) return;
    
            lock (_lock)
            {
                _dict.Clear();
                AddRange(newKeyValues);
                _readOnly = null;
            }
        }
    }
