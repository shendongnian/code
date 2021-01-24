    public class Syncer
    {
        private int flag = 0;
        // Data is synced periodically and on user request
        // and these two calls may overlap
        public void SyncData()
        {
            if (Interlocked.Exchange(ref flag, 1) == 1)
            {
                return;
            }
            // Sync data...
            // It is enough that one thread is syncing data
            Interlocked.Exchange(ref flag, 0);
        }
    }
