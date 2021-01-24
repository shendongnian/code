    public interface IRepository<T>
    {
    }
    public class Repository<T> : IRepository<T>
    {
    }
    public static class RepositoryFactory
    {
        public static IRepository<T> GetInstance<T>()
                    where T : new()
        {
            return new Repository<T>();
        }
    }
