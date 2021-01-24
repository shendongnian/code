    public interface IEntityDelta<in T> : IEntityDelta 
        where T : IEntity
    {
        void MakeDelta(T entity); // this is allowed
        //T Entity { get; set; } // this won't work
    }
    public class EntityDelta<T> : IEntityDelta<T> 
        where T : class, IEntity
    {
        public T Entity { get; set; }
        public EntityDelta(T entity) => Entity = entity;
        public void MakeDelta(T entity) { }
    }
    public interface IEntityDelta { }
    public abstract class Entity : IEntity { }
    public class Order : Entity { }
    public interface IEntity { }
