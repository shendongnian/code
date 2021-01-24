    public abstract class EntityController<T> : Controller where T : class, IEntityManager
    {
        protected(T manager)
        {
            Manager = manager
        }
    
        protected T Manager { get; }
    }
