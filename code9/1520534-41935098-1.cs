    // Class for initiating registrations.
    public static class Startup
    {
        public static InitContainer(IUnityContainer container)
        {
            var section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            section.Configure(container);
        }
    }
    
    // Some example class...
    public class SomeFactory : IFactory
    {
        private readonly IUnityContainer _container;
    
        public SomeFactory(IUnityContainer container)
        {
            _container = container;
        }
    
        public IDataInterface Create()
        {
            // return the implementation.
            return _container.Resolve<IDataInterface>();
        }
    }
