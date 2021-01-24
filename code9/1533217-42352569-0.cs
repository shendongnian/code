    public class Repository<T> : IRepository<T> where T : class, 
    {
       public IQueryable<T> Get()
       {
          return _dbContext.Set<T>();
       }
       //...
    }
