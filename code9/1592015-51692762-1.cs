        private readonly IDbContext _context;
        public EfRepository(NopaDbContext context)
        {
            this._context = context;
        }
        protected virtual DbSet<TEntity> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<TEntity>();
                return _entities;
            }
        }
