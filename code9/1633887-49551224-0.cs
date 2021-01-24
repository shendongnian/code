    private void StopTreeWatcher()
    {
        lock (bTreeWatcherStarted)
        {
            if (bTreeWatcherStarted)
            {
                if (treeChangeWatcher != null)
                {
                    treeChangeWatcher.EventArrived -= OnTreeChangeEventArrived;
                    treeChangeWatcher.Dispose();
                    treeChangeWatcher = null;
                }
                bTreeWatcherStarted = false;
            }
        }
    }
