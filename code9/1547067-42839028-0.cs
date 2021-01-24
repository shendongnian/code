    public class Syncer 
    {
        private bool syncInProgress = false;
        private object lockObject = new object();
    
        // Data is synced periodically and on user request
        // and these two calls may overlap
        public void SyncData() {
            try {
               Monitor.TryEnter(lockObject, ref syncInProgress); 
               if (syncInProgress) {
                   // The critical section.
                   // Sync data...
                   // It is enough that one thread is syncing data
               }
               else {
                   // The lock was not acquired.
                   return;
               }
            }
            finally {
               // Ensure that the lock is released.
               if (syncInProgress) {
                  Monitor.Exit(lockObject);
               }
            }
        }
    }
