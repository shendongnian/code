    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
            public DbContext Context { get; protected set; }
    
            public BaseRepository()
            {
                this.Context = new AppDbContext();
            }
    
            public BaseRepository(AppDbContext context)
            {
                this.Context = context;
            }
    
            public IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
            {
                var query = Context.Set<T>().AsQueryable();
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
    
                return query;
            }
    
            public DbEntityEntry<T> Entry(T entity)
            {
                return this.Context.Entry(entity);
            }
    
            public virtual void InsertOrUpdate(params T[] entities)
            {
                foreach (var entity in entities)
                {
                    this.Context.Entry(entity).State = EntityState.Added;
                }
            }
    
            public void SaveChanges()
            {
                this.Context.SetCurrentStateToEntities();
                this.Context.SaveChanges();
    
                this.Context.SetToUndefined();
            }
        }
