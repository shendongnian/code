    public class Syncer 
    {
        private object lockObject = new object();
    
        // Data is synced periodically and on user request
        // and these two calls may overlap
        public void SyncData() {
            if(Monitor.TryEnter(lockObject)){
               try {
                   // The critical section.
                   // Sync data...
                   // It is enough that one thread is syncing data
               }
               finally {
                   // Ensure that the lock is released.
                   Monitor.Exit(lockObject);
               }
            }
            else {
               // The lock was not acquired.
               return;
            }
        }
    }
