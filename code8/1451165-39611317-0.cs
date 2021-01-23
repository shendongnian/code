    public interface IResourceStorageFactory
    {
        IResourceStorage Create(int numberOfResources);
    }
    public class ResourceStorageFactory : IResourceStorageFactory
    {
        public IResourceStorage Create(HttpRequestMessage request)
        {
            var connectionString = ChooseDbConnectionStringBasedOnRequestContext(request);
            return new ResourceStorage(connectionString);
        }
    }
