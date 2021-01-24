    public class Hub
    {
        private Dictionary<string, List<Action<int>>> _events = new Dictionary<string, List<Action<int>>>();
        public void AddListener(string name, Action<int> callback)
        {
            if (!_events.ContainsKey(name))
                _events.Add(name, new List<Action<int>>());
            var list = _events[name];
            list.Add(callback);
        }
        public void Invoke(string name, int message)
        {
            if (_events.ContainsKey(name))
            {
                var list = _events[name];
                foreach (var action in list)
                {
                    action(message);
                }
            }
        }
    }
