    public interface IService {}
    public interface IFirstService : IService {}
    public interface ISecondService : IService {}
    public class FirstService : IFirstService {}
    public class SecondService : ISecondService {}
    
    public class ServiceFactory : IServiceFactory {
        public IService CreateService<IService>(Type class, string url)
            {
                // logic of creation
                new class(url)
            }
    }
