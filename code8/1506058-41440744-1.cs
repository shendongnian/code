    public class LogFactory
    {
        public ILogger Get<T>() where T : ILogger
        {
            ILogger instance = null;
            if (typeof(T) == typeof(CustomerLogger))
            {
                instance = (T)Activator.CreateInstance(typeof(T), "CustomerLogger", "Header", "Layout", Level.Verbose);
            } 
            else if (...)
            {
                ...etc
            }
            return instance;
        }
    } 
