    public abstract class ServiceProvider<T> where T : new()
    {
        public static T Create()
        {
            return new T();
        }
    }
    
