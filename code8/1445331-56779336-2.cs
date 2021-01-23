    public class Repository<T> : IRepository<T> where T : class
        {
            DataContext context;
            DbSet<T> db;
            public Repository(DataContext context)
            {
                this.context = context;
                db = context.Set<T>();
    
            }
            public void Add(T entity)
            {
                db.Add(entity);
            }
    
            public IQueryable<T> GetAll()
            {
                return db;
            }
    
            public async Task<T> GetByIdAsync(int id)
            {
                return await Task<T>.Run(() =>
                {
                    return db.FindAsync(1);
                });
            }
    
            public void Remove(T entity)
            {
                db.Remove(entity);
            }
    
            public async Task<int> SaveChangeAsync()
            {
                return await Task<T>.Run(() =>
                {
                    return context.SaveChangesAsync();
                });
            }
    
            public void Update(T entity)
            {
                context.Entry<T>(entity).State = EntityState.Modified;
            }
        }
