    public class SyncTelemetryChannel : ITelemetryChannel
    {
            private bool _disposed = false;
    
            /// <summary>
            /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
            /// </summary>
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
    
            /// <summary>
            /// Releases unmanaged and - optionally - managed resources.
            /// </summary>
            /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
            protected virtual void Dispose(bool disposing)
            {
                if (_disposed)
                    return;
    
                if (disposing)
                {                    
                    // Free any other managed objects here.                    
                }
    
                // Free any unmanaged objects here.
                _disposed = true;
            }
    
    }
