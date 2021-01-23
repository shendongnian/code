    public interface IRepository
    {
        User GetUser();
    }
    public interface IConnectionFactory
    {
        IDisposable CreateConnection();
    }
