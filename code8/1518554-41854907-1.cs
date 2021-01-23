    public class SingletonAppContext : ISingletonAppContext //as singleton
    {
        //Source code where no data context needed
    }
    
    public class RequestAppContext : IRequestAppContext
    {
        public RequestAppContext(ISingletonAppContext appContext, IDataContext dataContext)
        {
        }
        //Source code where data context is needed
    }
