    public class UnitOfWork : IDisposable
        {
            private GenericRepository<YourEntity> yourRepository;
    
            private DbContext context;
    
            public UnitOfWork(DbContext context)
            {
                this.context = context;
            }
    
            public GenericRepository<YourEntity> YourRepository
            {
                get
                {
                    if (this.yourRepository== null)
                    {
                        this.yourRepository= new GenericRepository<YourEntity>(context);
                    }
                    return yourRepository;
                }
            }
    }
