    public class SomeClassThatMultipleThreadsAccess
    {
        private readonly object _lockObject = new object();
        private bool _isLocked = false;
        public void MethodThatGetsCalledConcurrently()
        {
            if (_isLocked) return;
            lock (_lockObject)
            {
                _isLocked = true;
                try
                {
                    // do something
                }
                finally
                {
                    _isLocked = false;
                }
            }
        }
    }
 
