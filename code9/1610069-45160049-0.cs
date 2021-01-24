    // Core layer
    public interface IUnitOfWork
    {
        T CreateRepository<T>() where T : IRepository;
    }
    // Composition Root
    public class UnitOfWork : IUnitOfWork
    {
        // ...
    }
