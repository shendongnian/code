    public class GenericRepository<TEntity> where TEntity : class
        {
            internal DbContext dbContext;
            internal DbSet<TEntity> dbSet;
        
            public GenericRepository(DbContext context)
            {
                this.dbContext = context;
                this.dbSet = context.Set<TEntity>();
            }
        
            public virtual async Task<IEnumerable<TEntity>> GetAsync(
                Expression<Func<TEntity, bool>> filter = null,
                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                string includeProperties = "",
                int first = 0, int offset = 0)
            {
                IQueryable<TEntity> query = dbSet;
        
                if (filter != null)
                {
                    query = query.Where(filter);
                }
        
                if (offset > 0)
                {
                    query = query.Skip(offset);
                }
                if (first > 0)
                {
                    query = query.Take(first);
                }
        
                foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
        
                if (orderBy != null)
                {
                    return await orderBy(query).ToListAsync();
                }
                else
                {
                    return await query.ToListAsync();
                }
            }
        }
