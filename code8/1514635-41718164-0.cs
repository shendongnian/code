    public class DictionaryList<TKey, TValue>
    {
        private Dictionary<TKey, TValue> _dict;
        private List<TKey> _list;
        public TValue this[TKey key]
        {
            get { return _dict[key]; }
            set { _dict[key] = value; }
        }
        public DictionaryList()
        {
            _dict = new Dictionary<TKey, TValue>();
            _list = new List<TKey>();
        }
        public void Add(TKey key, TValue value)
        {
            _dict.Add(key, value);
            _list.Add(key);
        }
        public IEnumerable<TValue> GetValuesReverse()
        {
            for (int i = _list.Count - 1; i >= 0; i--)
                yield return _dict[_list[i]];
        }
    }
