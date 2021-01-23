    public interface IRepository : IDisposable {
       User GetUser();
       //other methods, doesn't matter
    }
    public interface IRepositoryFactory {
        IRepository Create();
    }
