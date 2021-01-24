       private ReaderWriterLock _readerWriterLock = new ReaderWriterLock();
        private void SuspendExeutionStrategy()
        {
            _readerWriterLock.AcquireReaderLock(_timeout);
            Interlocked.Increment(ref _pendingTransactions);
            MyConfiguration.SuspendExecutionStrategy = true;
            _readerWriterLock.ReleaseReaderLock();
        }
        private void ResetSuspension()
        {
            _readerWriterLock.AcquireWriterLock(_timeout);
            Interlocked.Decrement(ref _pendingTransactions);
            if (_pendingTransactions < 1)
            {
                MyConfiguration.SuspendExecutionStrategy = false;
            }
            _readerWriterLock.ReleaseWriterLock();
        }
