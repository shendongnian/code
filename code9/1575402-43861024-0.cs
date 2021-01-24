    public class MyClass
    {
        private int _flag;
    
        public async Task FooAsync()
        {
            try
            {
                if (Interlocked.CompareExchange(ref _flag, 1, 0) == 1)
                {
                    return;
                }
    
                // do stuff
            }
            finally
            {
                Interlocked.Exchange(ref _flag, 0);
            }
        }
    }
