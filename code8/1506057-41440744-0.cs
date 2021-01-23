    public class LogFactory
    {
        public ILogger Get<T>() where T : ILogger
        {
            if (typeof(T) == typeof(CustomerLogger))
            {
                instance = (T)Activator.CreateInstance(typeof(T), "CustomerLogger", "Header", "Layout", Level.Verbose);
            } 
            else if (...)
            {
                ...etc
            }
            return instance
        }
    } 
