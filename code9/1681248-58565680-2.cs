    // Abstract type
    public interface IRepository<T>
    {
        Add(T obj);
    }
    // Concete type
    public class UserRepository : IRepository<User>
    {
        public UserRepository(/* Specific dependencies */) {}
        Add(User obj) { /* [...] */ }
    }
    // Decorator
    public class LoggingRepository<T> : IRepository<T>
    {
        private readonly IRepository<T> _inner;
        public LoggingRepository<T>(IRepository<T> inner) => _inner = inner;
        Add(T obj) 
        {
            Console.Log($"Adding {obj}...");
            _inner.Add(obj);
            Console.Log($"{obj} addded.");
        }
    }
