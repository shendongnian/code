    public class GenericRepository<T> : IGenericRepository where T : class, new()
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _set;
        public GenericRepository(DbContext context)
        {
            _context = _db;
            _set = _context.Set<T>();
        }
        public IQueryable<T> Query => _set.Where(m=>m.Active == true);
        public virtual void Add(T entity) => _set.Add(entity);
        public virtual void Update(T entity) => this._context.Entry(entity).State = EntityState.Modified;
        public virtual void Delete(T entity) =>  _set.Remove(entity);
    }
