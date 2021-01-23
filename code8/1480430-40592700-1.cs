    public class ValueOrDictionary : IDictionary<object, ValueOrDictionary>
    {
        private readonly IDictionary<object, ValueOrDictionary> storage = new Dictionary<object, ValueOrDictionary>();
        private object value;
        private bool isValue = false;
        public ValueOrDictionary this[object key]
        {
            get
            {
                if (isValue)
                {
                    throw new InvalidOperationException();
                }
                ValueOrDictionary subLevel;
                if (!storage.TryGetValue(key, out subLevel))
                {
                    subLevel = new ValueOrDictionary();
                    storage[key] = subLevel;
                }
                return subLevel;
            }
            set
            {
                storage[key] = value;
            }
        }
        public object Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = value;
                isValue = value != null;
            }
        }
        // ... rest of IDictionary<,> implementation
