    public interface IKeyedIdentity
    {
         long Id { get; }
    }
    public interface INamedIdentity: IKeyedIdentity
    {
         string Name { get; }
    }
    public class MyClass<T> where T: IKeyedIdentity
    {
         public void Create(T entity) { ... }
         public void Update(T entity) { ... }
         public T GetById(long id) { ... }
         public Q GetByName<Q>(string name)
             where Q : T, INamedEntity
         { ... } 
    }
