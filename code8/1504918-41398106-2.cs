    public class Repository<T> : IRepository<T>
        where T : EntityBase
    {
        internal MyDbContext context;
        internal DbSet<T> dbSet; 
        public Repository()
        {
            context = new MyDbContext();
            this.dbSet = context.Set<T>(); 
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }
        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }
        public void Delete(int id)
        {
            dbSet.Remove(dbSet.Find(id));
        }
        public T GetById(int id)
        {
            return dbSet.Find(id);
        }
        public IEnumerable<T> GetAll()
        {
            return dbSet.AsEnumerable();
        }
        public void Update(T entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }
        public void Save()
        {
            context.SaveChanges(); 
        }
    }
