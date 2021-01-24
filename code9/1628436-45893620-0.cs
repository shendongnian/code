    public RepositoryBase(DataContext _context)
        {
           if (_context.Database.Connection.State == ConnectionState.Closed)
           {
                this._context = null;
                this._dbSet = null;
           }
           else
           {
                this._context = _context;
                this._dbSet = _context.Set<TEntity>();
           }
