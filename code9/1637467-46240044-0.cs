    using Microsoft.Practices.Unity;
    ...
    public class ServiceFactory : IServiceFactory
    {
        T IServiceFactory.CreateClient<T>()
        {
            return ObjectBase.Container.Resolve<T>();
        }
    }
