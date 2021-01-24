    public class SomeClassThatMultipleThreadsAccess
    {
        private readonly object _lockObject = new object();
        public void MethodThatGetsCalledConcurrently()
        {
            if(Monitor.TryEnter(_lockObject))
            {
                try
                {
                    // only one thread at a time can execute this in
                    // one instance of the class.
                    // If _lockObject is static then only one thread at
                    // a time can execute this across all instances of
                    // the class.
                }
                finally // very important - if we don't exit then nothing else can enter.
                {
                    Monitor.Exit(_lockObject);
                }
            }
        }
    }
