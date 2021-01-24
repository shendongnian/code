    public class MediatRNotification<T> : INotification
    {
        T Instance { get; }
    
        public MediatRNotification(T instance)
        {
            Instance = instance;
        }
    }
