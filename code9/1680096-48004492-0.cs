    public class DisposableDbObjectProvider : IDisposableDbObjectProvider, IDisposable 
    {
        private DisposableDbObject _obj  = new DisposableDbObject("D:\\path\to\file");
        private ReaderWriteLockSlim _lock = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);
        
        public DisposableDbObject AquireDb()
        {
             if(_lock.TryEnterReaderLock(100)) // how long to wait until entering fails
             {
                 return _obj;
             }
             else
             {
                // unable to enter read lock in timeout
                // do something
             }
        }
        public void ReleaseDb()
        {
             // we need to exit lock after we are done with reading
             _lock.ExitReadLock();
        }
        public void UpdateDb() 
        {
             if(_lock.TryEnterWriteLock(500)) // how long to wait until entering fails
             {
                _obj.Dispose();
                _obj = new DisposableDbObject("D:\\path\to\new\file");
                _lock.ExitWriteLock(); // We need to leave write lock to let read lock to be acquired
             }
             else
             {
                 // unable to enter write lock in timeout
                 // do something
             }
        }
    
        public void Dispose() 
        {
            _obj.Dispose();
        }
    }
