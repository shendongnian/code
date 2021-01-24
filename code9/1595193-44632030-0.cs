    public interface IEntity<T> where T : class
    {
        Expression<Func<T, bool>> GetByIdPredicate(long id);
    }        
        
    public partial class User : IEntity<User>
    {
       public int UserID { get; set; }
        
       public Expression<Func<User, bool>> GetByIdPredicate(long id)
       {
          return (User entity) => entity.UserID == id;
       }
    }
    
    class Repository<T>:IRepository<T> where T : class, IEntity, new()
    {
      private readonly ApplicationContext context;
      private DbSet<T> entities;
      T dummyEntity;
      public Repository(PrincipalServerContext context)
      {
            this.context = context;
            entities = context.Set<T>();
            dummyEntity = new T();
      }
      public T Get(long id)
      {
         return entities.SingleOrDefault(dummyEntity.GetByIdPredicate(id));
      }
