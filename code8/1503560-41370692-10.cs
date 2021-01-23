    internal class DynamicTransactionObject : DynamicObject, ITransaction, IDictionary<string, object>
    {
        private readonly Dictionary<string, object> _data = new Dictionary<string, object>();
        public DynamicTransactionObject()
        {
            //Set initial default values for the two properties to populate the entries in the dictionary.
            _data[nameof(Response)] = default(short);
            _data[nameof(Request)] = default(bool);
        }
        public short Response
        {
            get
            {
                return (short)_data[nameof(Response)];
            }
            set
            {
                if (Response.Equals(value))
                    return;
                _data[nameof(Response)] = value;
                OnPropertyChanged();
            }
        }
        public bool Request
        {
            get
            {
                return (bool)_data[nameof(Request)];
            }
            set
            {
                if (Request.Equals(value))
                    return;
                _data[nameof(Request)] = value;
                OnPropertyChanged();
            }
        }
        
        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return _data.Keys;
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            
            return _data.TryGetValue(binder.Name, out result);
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            object oldValue;
            _data.TryGetValue(binder.Name, out oldValue)
            _data[binder.Name] = value;
            if(!Object.Equals(oldValue, value)
               OnPropertyChanged(binder.Name);
            return true;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #region IDictionary<string,object> members
        IEnumerator<KeyValuePair<string, object>> IEnumerable<KeyValuePair<string, object>>.GetEnumerator()
        {
            return _data.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_data).GetEnumerator();
        }
        void ICollection<KeyValuePair<string, object>>.Add(KeyValuePair<string, object> item)
        {
            ((ICollection<KeyValuePair<string, object>>)_data).Add(item);
        }
        void ICollection<KeyValuePair<string, object>>.Clear()
        {
            _data.Clear();
        }
        bool ICollection<KeyValuePair<string, object>>.Contains(KeyValuePair<string, object> item)
        {
            return ((ICollection<KeyValuePair<string, object>>)_data).Contains(item);
        }
        void ICollection<KeyValuePair<string, object>>.CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            ((ICollection<KeyValuePair<string, object>>)_data).CopyTo(array, arrayIndex);
        }
        bool ICollection<KeyValuePair<string, object>>.Remove(KeyValuePair<string, object> item)
        {
            return ((ICollection<KeyValuePair<string, object>>)_data).Remove(item);
        }
        int ICollection<KeyValuePair<string, object>>.Count
        {
            get { return _data.Count; }
        }
        bool ICollection<KeyValuePair<string, object>>.IsReadOnly
        {
            get { return ((ICollection<KeyValuePair<string, object>>)_data).IsReadOnly; }
        }
        bool IDictionary<string, object>.ContainsKey(string key)
        {
            return _data.ContainsKey(key);
        }
        void IDictionary<string, object>.Add(string key, object value)
        {
            _data.Add(key, value);
        }
        bool IDictionary<string, object>.Remove(string key)
        {
            return _data.Remove(key);
        }
        bool IDictionary<string, object>.TryGetValue(string key, out object value)
        {
            return _data.TryGetValue(key, out value);
        }
        object IDictionary<string, object>.this[string key]
        {
            get { return _data[key]; }
            set { _data[key] = value; }
        }
        ICollection<string> IDictionary<string, object>.Keys
        {
            get { return _data.Keys; }
        }
        ICollection<object> IDictionary<string, object>.Values
        {
            get { return _data.Values; }
        }
    #endregion
    }
