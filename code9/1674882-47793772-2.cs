    class DefaultDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        private readonly Func<TKey, TValue> _defaultValueFactory;
    
        public DefaultDictionary(TValue defaultValue)
        {
            _defaultValueFactory = new Func<TKey, TValue>(x => defaultValue);
        }
    
        public DefaultDictionary(Func<TValue> defaultValueFactory)
        {
            _defaultValueFactory = new Func<TKey, TValue>(x => defaultValueFactory()) ?? throw new ArgumentNullException(nameof(defaultValueFactory));
        }
    
        public DefaultDictionary(Func<TKey, TValue> defaultValueFactory)
        {
            _defaultValueFactory = defaultValueFactory ?? throw new ArgumentNullException(nameof(defaultValueFactory));
        }
    
        public new TValue this[TKey key]
        {
            get
            {
                var hasKey = ContainsKey(key);
    
                if (!hasKey)
                {
                    var defaultValue = _defaultValueFactory(key);
                    Add(key, defaultValue);
                }
    
                return base[key];
            }
            set
            {
                base[key] = value;
            }
        }
    }
