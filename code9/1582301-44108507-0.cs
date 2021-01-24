    public class RequestPerPeriodLimiter : IDisposable
    {
        private readonly SemaphoreSlim _semaphore;
        private readonly Timer _timer;
        private int _currentRequests;
    
        public RequestPerPeriodLimiter( int count, TimeSpan period )
        {
            _semaphore = new SemaphoreSlim( count, count );
            _timer = new Timer( OnTimer, this, period, period );
        }
    
        private void OnTimer( object state )
        {
            var requests = Interlocked.Exchange( ref _currentRequests, 0 );
            _semaphore.Release( requests );
        }
    
        public void Wait()
        {
            _semaphore.Wait();
            Interlocked.Increment( ref _currentRequests );
        }
    
        public async Task WaitAsync()
        {
            await _semaphore.WaitAsync().ConfigureAwait( false );
            Interlocked.Increment( ref _currentRequests );
        }
    
        #region IDisposable Support
        private bool disposedValue = false; // Dient zur Erkennung redundanter Aufrufe.
    
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
