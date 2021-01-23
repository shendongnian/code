    public class ServiceProvider<T>
    {
        public static T Create()
        {
            return (T)Activator.CreateInstance(typeof(T));
        }
    }
