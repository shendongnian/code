    public class clsDBConn : IDisposable
        {
            private bool disposedValue = false; 
            ....
            ....
            ....
    
            protected virtual void Dispose(bool disposing)
            {
                if (!disposedValue)
                {
                    if (disposing)
                    {
                        // TODO: dispose managed state (managed objects).
                    }
                    
                    disposedValue = true;
                }
            }
            
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
        }
