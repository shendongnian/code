    public class GenericRepository<TDbSet, TDbContext> : 
        IGenericRepository<TDbSet> where TDbSet : class
        where TDbContext : DbContext, new()
    {
        internal DbContext _context;
        internal DbSet<TDbSet> _dbSet;
   
        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TDbSet>();
        }
        public GenericRepository() : this(new TDbContext())
        {
        }
        /// <summary>
        /// This constructor will set the database of the repository 
        /// to the one indicated by the "database" parameter
        /// </summary>
        /// <param name="context"></param>
        /// <param name="database"></param>       
        public GenericRepository(string database = null)
        {
            SetDatabase(database);
        }
        public void SetDatabase(string database)
        {
            var dbConnection = _context.Database.Connection;
            if (string.IsNullOrEmpty(database) || dbConnection.Database == database)
                return;
            if (dbConnection.State == ConnectionState.Closed)
                dbConnection.Open();
            _context.Database.Connection.ChangeDatabase(database);
        }
        public virtual IQueryable<TDbSet> Get()
        {
            return _dbSet;
        }
        public virtual TDbSet GetById(object id)
        {
            return _dbSet.Find(id);
        }
        public virtual void Insert(TDbSet entity)
        {
            _dbSet.Add(entity);
        }
        public virtual void Delete(object id)
        {
            TDbSet entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }
        public virtual void Delete(TDbSet entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }
        public virtual void Update(TDbSet entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }
        public virtual void Save()
        {
            _context.SaveChanges();
        }
    }
