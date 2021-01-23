    class TestClass
    {
        private InnerClass _innerClass;
        private readonly object _syncObject = new object();
    
        public InnerClass Get()
        {
            lock (_syncObject)
            {
                return _innerClass;
            }
        }
    
        public void Set(InnerClass innerClass)
        {
            lock (_syncObject)
            {
                _innerClass = innerClass;
            }
        }
    }
