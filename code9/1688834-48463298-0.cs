    public class UnitOfWork : IUnitOfWork
    {
        private readonly FitaholicContext context;
    
        public UnitOfWork(FitaholicContext context)
        {
            this.context = context;
        }
        private Repository _repository;
        public Repository repository =>
            this._repository ?? (this._repository =
                new Repository(this.context));
        public Task CompleteAsync()
        { 
            return context.SaveChangesAsync();
        }
    }
