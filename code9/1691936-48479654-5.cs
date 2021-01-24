    public class SomeClassThatMultipleThreadsAccess
    {
        private readonly object _lockObject = new object();
        public void MethodThatGetsCalledConcurrently()
        {
            if(Monitor.TryEnter(_lockObject))
            {
                try
                {
                    // do something
                }
                finally
                {
                   Monitor.Exit(_lockObject);
                }
            }
        }
    }
 
