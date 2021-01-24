    public class GenericRepository<T, Key> : IGenericRepository<T, Key>
    {
        private readonly ApplicationDbContext _context;
        private DbSet<T> _entities;
    
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }
    
        // No need to async IQueryable
        public IQueryable<T> GetAll() => _entities.AsQueryable();
    
        public Task<T> GetAsync(Key id)
        {
            throw new NotImplementedException();
        }
    }
