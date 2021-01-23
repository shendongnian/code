    public class SingletonAppContext : ISingletonAppContext //as singleton
    {
    }
    
    public class RequestAppContext
    {
        public RequestAppContext(ISingletonAppContext appContext, IDataContext dataContext)
        {
        }
    }
