    public class Foo {
        private readonly ReaderWriterLockSlim _syncLock = new ReaderWriterLockSlim();
    
        public void Master() {
          // Exclusive (write) lock: only Master allowed to run
          _syncLock.EnterWriteLock();
    
          try {
            //run code...
          }
          finally {
            _syncLock.ExitWriteLock();
          }   
        }
    
        public void Slave1() {
          // Read lock: you can run Slave2 (with another Read lock), but not Master 
          _syncLock.EnterReadLock();
    
          try {
            //run code...
          }
          finally {
            _syncLock.ExitReadLock();
          }         
        }
    
        public void Slave2() {
          // Read lock: you can run Slave1 (with another Read lock), but not Master 
          _syncLock.EnterReadLock();
    
          try {
            //run code...
          }
          finally {
            _syncLock.ExitReadLock();
          }         
        }   
    }
