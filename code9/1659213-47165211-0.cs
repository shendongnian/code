    public class SingleUserLock : IDisposable
    {
        private SingleUserSemaphore _parent;
        public SingleUserLock(SingleUserSemaphore parent)
        {
            _parent = parent;
        }
        public bool IsLoggedIn => _parent?.CurrentUser == this;
        public void Unlock()
        {
            _parent?.Unlock();
            _parent = null;
        }
        public void Dispose()
        {
            Unlock();
        }
    }
    public class SingleUserSemaphore
    {
        private readonly object _lockObject = new object();
        public SingleUserLock CurrentUser { get; private set; }
        public bool TryLogin()
        {
            if (Monitor.TryEnter(_lockObject))
            {
                CurrentUser = new SingleUserLock(this);
                return true;
            }
            return false;
        }
        public void Unlock()
        {
            try
            {
                Monitor.Exit(_lockObject);
                CurrentUser = null;
            }
            catch (Exception ex) { };
        }
    }
