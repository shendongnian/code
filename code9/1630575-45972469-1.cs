    class ThreadSafeCalls
    {
        private object mLock = new object();
        // other fields...
    
        public void AddGridRow(DataGridView gv)
        {
            lock (mLock) {
                // ... your existing implementation.
            }
        }
    
        public void AddGridCellData(DataGridView gv, int column, int rowID, string value)
        {
            lock (mLock) {
                // ... your existing implementation.
            }
        }
    }
