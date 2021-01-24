    public class RentalsRepository<T> : IRentalsRepository<T> where T : BaseClass
    {
       private readonly RentalsDBContext _Context;
       private DbSet<T> entities;
       string errorMessage = string.Empty;
       public RentalsRepository(RentalsDBContext _Context)
       {
          this._Context = _Context;
          entities = _Context.Set<T>();
       }
       public T Get(string Id)
       {
          return entities.SingleOrDefault(e => e.Id == Id);
       }
       public T GetByPredicate(Func<T, bool> predicate)
       {
          return entities.FirstOrDefault(predicate);
       }
    }
