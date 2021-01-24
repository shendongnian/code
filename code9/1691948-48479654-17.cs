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
                finally // very important - if we don't exit then nothing else can enter.
                {
                    Monitor.Exit(_lockObject);
                }
            }
        }
    }
 
