    public abstract class ServiceProvider
    {
    }
    public class ServiceManager
    {
        private readonly Dictionary<Type, ServiceProvider> repository;
        public ServiceManager()
        {
            repository = new Dictionary<Type, ServiceProvider>();
        }
        public ServiceProvider Get<T>() where T : ServiceProvider
        {
            if (repository.ContainsKey(typeof(T)))
                return repository[typeof(T)];
            var service = (T)Activator.CreateInstance<T>();
            repository[typeof(T)] = service;
            return service;
        }
    }
