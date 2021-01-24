    class Blah
    {
        private List<Action<object>> _handlers = new List<Action<object>>();
        public void AddListener<T>(Action<T> handler)
        {
            //graceful type checking code goes in here somewhere
            _handlers.Add(o => handler((T) o));
        }
        void RaiseEvent(object eventArgs)
        {
            foreach (var handler in _handlers) handler(eventArgs);
        }
    }
