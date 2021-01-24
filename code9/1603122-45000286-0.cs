    public class SometimesNotSynchronizedWarning
    {
        private readonly List<string> _list = new List<string>();
        private readonly object _lockObj = new object();
    
        public bool Contains(string item)
        {
            lock (_lockObj)
            {
                return _list.Contains(item);
            }
        }
    
        public void Add(string item)
        {
            // R# warning: "The field is sometimes used inside synchronized block
            // and sometimes used without synchronization":
            _list.Add(item);
        }
    }
