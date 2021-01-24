    class Store {
        readonly Dictionary<Type, Action<object>> _callbacks = new Dictionary<Type, Action<object>>();
        public void Register<T>(Action<T> updateCallback) {
                                                              // cast here
            _callbacks.Add(typeof(T), value => updateCallback((T) value));
        }
        public void Save<T>(T value) {
            _callbacks[typeof(T)](value);
        }
    }
