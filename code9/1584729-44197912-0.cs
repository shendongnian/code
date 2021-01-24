    public interface IServiceFactory
    {
        IFirstService CreateFirstService(string url);
        ISecondService CreateSecondService(string url);
    }
    public class ServiceFactory : IServiceFactory
    {
        public IFirstService CreateFirstService(string url) { ... }
        public ISecondService CreateSecondService(string url) { ... }
    }
