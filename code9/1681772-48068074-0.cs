    public interface IEntity
    {
      Guid Id { get; set; }
    }
    
    public class GenericRepository<T> where T class, IEntity
    {
      public async Task AddAsync (T t)
      {
        ...
        T.Id = Guid.NewGuid();
        ...
      }
    }
