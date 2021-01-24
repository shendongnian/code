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
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                   _genericRepo.Dispose();
                }
            }
            this.disposed = true;
        }
    
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
