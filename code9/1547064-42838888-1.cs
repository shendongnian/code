    public class Syncer
    {
        private RefBool mIsSyncInProgress = false;
        public void SyncData()
        {
            if (Interlocked.Exchange(ref mIsSyncInProgress, true))
            {
                return;
            }
            // Sync data...
            // It is enough that one thread is syncing data
            Interlocked.Exchange(ref mIsSyncInProgress, false);
        }
    }
