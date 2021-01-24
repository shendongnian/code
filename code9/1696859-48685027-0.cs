    public class MyContext
    {
        private readonly object _lock = new object();
        public delegate bool MyDelegate(MyContext context);
        private MyDelegate _delegate;
    
        public MyContext()
        {
        }
    
        public void AddDelegate(MyDelegate del)
        {
            lock (_lock)
            {
                _delegate += del;
            }
        }
    
        public void RemoveDelegate(MyDelegate del)
        {
            lock (_lock)
            {
                // You had a bug here, +=
                _delegate -= del;
            }
        }
    
        public void Go()
        {
            MyDelegate currentDelegate;
            lock (_lock)
            {
                currentDelegate = _delegate;
            }
            currentDelegate?.Invoke(this);
        }
    }
