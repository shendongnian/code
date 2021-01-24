    public class GenericService<T> : IGenericService<T>, IDisposable
        where T : BaseEntity
    {
        private IGenericRepository<T> _genericRepo;
    
        public GenericService(IGenericRepository<T> genericRepo)
        {
            _genericRepo = genericRepo;
        }
        . 
        .
        .
        private bool disposed = false;
        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return; 
          
            if (disposing) {
                _genericRepo.Dispose();
                // Free any other managed objects here.
                //
            }
          
            // Free any unmanaged objects here.
            //
            disposed = true;
        }    
    
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
