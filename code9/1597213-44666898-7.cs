    public sealed class BindableDynamicDictionary : DynamicObject, INotifyPropertyChanged
    {
        /// <summary>
        /// The internal dictionary.
        /// </summary>
        private readonly Dictionary<string, object> _dictionary;
        /// <summary>
        /// Creates a new BindableDynamicDictionary with an empty internal dictionary.
        /// </summary>
        public BindableDynamicDictionary()
        {
            _dictionary = new Dictionary<string, object>();
        }
        /// <summary>
        /// Copies the contents of the given dictionary to initilize the internal dictionary.
        /// </summary>
        public BindableDynamicDictionary(IDictionary<string, object> source)
        {
            _dictionary = new Dictionary<string, object>(source);
        }
		
        /// <summary>
        /// You can still use this as a dictionary.
        /// </summary>
        public object this[string key]
        {
            get { return _dictionary[key]; }
            set
            {
                _dictionary[key] = value;
                RaisePropertyChanged(key);
            }
        }
        /// <summary>
        /// This allows you to get properties dynamically.
        /// </summary>
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            return _dictionary.TryGetValue(binder.Name, out result);
        }
        /// <summary>
        /// This allows you to set properties dynamically.
        /// </summary>
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            _dictionary[binder.Name] = value;
            RaisePropertyChanged(binder.Name);
            return true;
        }
        /// <summary>
        /// This is used to list the current dynamic members.
        /// </summary>
        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return _dictionary.Keys;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            var propChange = PropertyChanged;
            if (propChange == null) return;
            propChange(this, new PropertyChangedEventArgs(propertyName));
        }
    }
