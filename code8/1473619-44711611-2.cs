    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Get(int id, string[] paths = null);
    }
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        public async Task<TEntity> Get(int id, string[] paths = null)
        {
            var model = await _dbSet.FindAsync(id);
            foreach (var path in paths)
            {
                _context.Entry(model).Reference(path).Load();
            }
            return model;
        }
    }
