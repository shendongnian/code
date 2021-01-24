    public interface IRepository<T> : where T : class
    {
         void Add(T item);
         IQueryable<T> Query();
         void SaveChanges(bool unitOfWork);
    }
    
    public class Repository<T> : IRepository<T>
    {
        ...
        public void Add(T item)
        {
            _dbContext.Entry(item).State = EntityState.Added;
        }
        public IQueryable<T> Query()
        {
            return _dbContext.Set<T>().AsQueryable();
        }
        public void SaveChanges(bool unitofWork = false)
        {
            if (!unitofWork)
            {
                 _dbContext.SaveChanges();
            }
        }
    }
