    public PersonEntity : IEntity
    {
        // public parameterless constructor
        public PersonEntity()
        {
        }
    }
    public abstract class BaseImplementation<T, U> : IHistory<T>
        where T : class, IEntity, new()
        where U : DbContext, new()
    {
        public T CreateEntity() 
        {
            var entity = new T();  
            // entity will be the type passed to `T` when instantiating `BaseImplementation`
        }
    }
