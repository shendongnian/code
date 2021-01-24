    [DebuggerDisplay( "Current Count = {_semaphore.CurrentCount}" )]
    public class TimedSemaphoreSlim : IDisposable
    {
        private readonly System.Threading.SemaphoreSlim _semaphore;
        private readonly System.Threading.Timer _timer;
        private int _releaseCount;
        public TimedSemaphoreSlim( int initialcount, TimeSpan period )
        {
            _semaphore = new System.Threading.SemaphoreSlim( initialcount );
            _timer = new System.Threading.Timer( OnTimer, this, period, period );
        }
        public TimedSemaphoreSlim( int initialCount, int maxCount, TimeSpan period )
        {
            _semaphore = new SemaphoreSlim( initialCount, maxCount );
            _timer = new Timer( OnTimer, this, period, period );
        }
        private void OnTimer( object state )
        {
            var releaseCount = Interlocked.Exchange( ref _releaseCount, 0 );
            if ( releaseCount > 0 )
                _semaphore.Release( releaseCount );
        }
        public WaitHandle AvailableWaitHandle => _semaphore.AvailableWaitHandle;
        public int CurrentCount => _semaphore.CurrentCount;
        public void Release()
        {
            Interlocked.Increment( ref _releaseCount );
        }
        public void Release( int releaseCount )
        {
            Interlocked.Add( ref _releaseCount, releaseCount );
        }
        public void Wait()
        {
            _semaphore.Wait();
        }
        public void Wait( CancellationToken cancellationToken )
        {
            _semaphore.Wait( cancellationToken );
        }
        public bool Wait( int millisecondsTimeout )
        {
            return _semaphore.Wait( millisecondsTimeout );
        }
        public bool Wait( int millisecondsTimeout, CancellationToken cancellationToken )
        {
            return _semaphore.Wait( millisecondsTimeout, cancellationToken );
        }
        public bool Wait( TimeSpan timeout, CancellationToken cancellationToken )
        {
            return _semaphore.Wait( timeout, cancellationToken );
        }
        public Task WaitAsync()
        {
            return _semaphore.WaitAsync();
        }
        public Task WaitAsync( CancellationToken cancellationToken )
        {
            return _semaphore.WaitAsync( cancellationToken );
        }
        public Task<bool> WaitAsync( int millisecondsTimeout )
        {
            return _semaphore.WaitAsync( millisecondsTimeout );
        }
        public Task<bool> WaitAsync( TimeSpan timeout )
        {
            return _semaphore.WaitAsync( timeout );
        }
        public Task<bool> WaitAsync( int millisecondsTimeout, CancellationToken cancellationToken )
        {
            return _semaphore.WaitAsync( millisecondsTimeout, cancellationToken );
        }
        public Task<bool> WaitAsync( TimeSpan timeout, CancellationToken cancellationToken )
        {
            return _semaphore.WaitAsync( timeout, cancellationToken );
        }
        #region IDisposable Support
        private bool disposedValue = false; // Dient zur Erkennung redundanter Aufrufe.
        private void CheckDisposed()
        {
            if ( disposedValue )
            {
                throw new ObjectDisposedException( nameof( TimedSemaphoreSlim ) );
            }
        }
        protected virtual void Dispose( bool disposing )
        {
            if ( !disposedValue )
            {
                if ( disposing )
                {
                    _timer.Dispose();
                    _semaphore.Dispose();
                }
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose( true );
        }
        #endregion
    }
