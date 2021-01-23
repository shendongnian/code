    public class ServiceProvider
    {
        public static T Create()
        {
            return (T)Activator.CreateInstance(typeof(T));
        }
    }
