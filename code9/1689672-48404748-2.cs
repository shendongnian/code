    public class Hub
    {        
        private Dictionary<string, Action<int>> _events = new Dictionary<string, Action<int>>();
        public void AddListener(string name, Action<int> callback)
        {
            if (!_events.ContainsKey(name))
                _events.Add(name, callback);
            else
            {
                var handler = _events[name];
                _events[name] = handler + callback;                
            }
        }
        public void Invoke(string name, int message)
        {
            if (_events.ContainsKey(name))
            {
                var handler = _events[name];
                handler(message);
            }
        }
    }
