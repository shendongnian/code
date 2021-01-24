    public class SmellyDictionary<T1, T2>: IDictionary<T1, T2>, ICollection where T2 : ICollection, new()
    {
        private readonly IDictionary<T1, T2> _dict = new Dictionary<T1, T2>();
        public T2 this[T1 key]
        {
            get
            {
                T2 value;
                if (!_dict.TryGetValue(key, out value))
                    _dict[key] = value = new T2(); // This stinks!
                return value;
            }
            set { _dict[key] = value; }
        }
        public bool Contains(KeyValuePair<T1, T2> item)
        {
            return _dict.Contains(item);
        }
        public bool ContainsKey(T1 key)
        {
            return _dict.ContainsKey(key) && _dict[key].Count > 0; // This hides the smell
        }
        public int Count { get { return _dict.Count(kvp => kvp.Value.Count > 0); } } // This hides the smell
        public void Add(T1 key, T2 value)
        {
            T2 currentValue;
            if (_dict.TryGetValue(key, out currentValue) && currentValue.Count > 0)
                throw new ArgumentException("A non empty element with the same key already exists in the SmellyDictionary");
            _dict[key] = value;
        }
        public void Add(KeyValuePair<T1, T2> item)
        {
            Add(item.Key, item.Value);
        }
        public bool Remove(T1 key)
        {
            return _dict.Remove(key);
        }
        public bool Remove(KeyValuePair<T1, T2> item)
        {
            return _dict.Remove(item);
        }
        public bool TryGetValue(T1 key, out T2 value)
        {
            return _dict.TryGetValue(key, out value);
        }
        public ICollection<T1> Keys { get { return _dict.Keys; } }
        public ICollection<T2> Values { get { return _dict.Values; } }
        public object SyncRoot { get { return ((ICollection)_dict).SyncRoot; } }
        public bool IsSynchronized { get { return ((ICollection)_dict).IsSynchronized; } }
        public IEnumerator<KeyValuePair<T1, T2>> GetEnumerator()
        {
            return _dict.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void Clear()
        {
            _dict.Clear();
        }
        public void CopyTo(Array array, int index)
        {
            _dict.CopyTo((KeyValuePair<T1, T2>[])array, index);
        }
        public void CopyTo(KeyValuePair<T1, T2>[] array, int arrayIndex)
        {
            _dict.CopyTo(array, arrayIndex);
        }
        public bool IsReadOnly { get { return _dict.IsReadOnly; } }
    }
