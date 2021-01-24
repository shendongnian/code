    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IRepository<Author> AuthorRepository =>
           new GenericRepository<Author>(_dbContext);
        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
