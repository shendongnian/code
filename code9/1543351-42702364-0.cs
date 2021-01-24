    public delegate void CancellableBackgroundJob(ICancellationProvider cancellation);
    public interface ICancellationProvider
    {
        bool CheckForCancel();
        void CheckForCancelAndBreak();
        void SleepWithCancel(int millis);
    }
    public class CancellableBackgroundWorker : Component, ICancellationProvider
    {
        private readonly ManualResetEvent _canceledEvent = new ManualResetEvent(false);
        private readonly CancellableBackgroundJob _backgroundJob;
        private volatile Thread _thread;
        private volatile bool _disposed;
        public EventHandler FinishedEvent;
        public CancellableBackgroundWorker(CancellableBackgroundJob backgroundJob)
        {
            _backgroundJob = backgroundJob;
        }
        protected override void Dispose(bool disposing)
        {
          Cancel();
          _disposed = true;
        }
        private void AssertNotDisposed()
        {
            if (_disposed)
                throw new InvalidOperationException("Worker is already disposed");
        }
        public bool IsBusy
        {
            get { return (_thread != null); }
        }
        public void Start()
        {
            AssertNotDisposed();
            if (_thread != null)
                throw new InvalidOperationException("Worker is already started");
            _thread = new Thread(DoWorkWrapper);
            _thread.Start();
        }
        public void Cancel()
        {
            AssertNotDisposed();
            _canceledEvent.Set();
        }
        private void DoWorkWrapper()
        {
            _canceledEvent.Reset();
            try
            {
                _backgroundJob(this);
                Debug.WriteLine("Worker thread completed successfully");
            }
            catch (ThreadAbortException ex)
            {
                Debug.WriteLine("Worker thread was aborted");
                Thread.ResetAbort();
            }
            finally
            {
                _canceledEvent.Reset();
                _thread = null;
                EventHandler finished = FinishedEvent;
                if (finished != null)
                    finished(this, EventArgs.Empty);
            }
        }
        #region ICancellationProvider
        // use explicit implementation of the interface to separate interfaces
        // I'm too lazy to create additional class
        bool ICancellationProvider.CheckForCancel()
        {
            return _canceledEvent.WaitOne(0);
        }
        void ICancellationProvider.CheckForCancelAndBreak()
        {
            if (((ICancellationProvider)this).CheckForCancel())
            {
                Debug.WriteLine("Cancel event is set, aborting the worker thread");
                _thread.Abort();
            }
        }
        void ICancellationProvider.SleepWithCancel(int millis)
        {
            if (_canceledEvent.WaitOne(millis))
            {
                Debug.WriteLine("Sleep aborted by cancel event, aborting the worker thread");
                _thread.Abort();
            }
        }
        #endregion
    }
