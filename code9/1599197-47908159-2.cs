    public class Repository<T> : IRepository<T> where T : class
    {
        DbContext db;
        DbSet<T> currentEntity;
        public Repository(DbContext db)
        {
            this.db = db;
            currentEntity = db.Set<T>();
        }
        public void Add(T TEntity)
        {
            currentEntity.Add(TEntity);
        } 
    
    
        public virtual List<T> GetAll()
        {
            return currentEntity.ToList<T>();
        }
    
        public ICollection<TType> Get<TType>(Expression<Func<T, bool>> where, Expression<Func<T, TType>> select) where TType : class
        {
            return currentEntity.Where(where).Select(select).ToList();
        }
    }
