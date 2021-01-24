    public class DoubleCheckedLockingWarning
    {
        private List<string> _instance;
        private readonly object _lockObj = new object();
        public List<string> GetInstance()
        {
            if (_instance != null) return _instance;
            lock (_lockObj)
                if (_instance == null)
                    // R# warning: "Possible incorrect implementation of Double-Check Locking.
                    // Checked field must be volatile or assigned from local variable
                    // after 'Thread.MemoryBarrier()' call":
                    _instance = new List<string>(); 
            return _instance;
        }
    }
