    class Foo {
    
        List<string> sharedResource;
        ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();
    
        public void reading() // multiple reading threads allowed, concurrency ok, lock this only if a thread enters the mutating block below.
        {
            try
            {
                _lock.EnterReadLock();
    
                //Do reading stuff here.
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }
    
        public void mutating() // this should lock any threads entering this block as well as lock the reading threads above
        {
            try
            {
                _lock.EnterWriteLock();
    
                //Do writing stuff here.
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }
    }
