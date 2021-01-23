    public class ServiceLocator : IServiceLocator
    {
        readonly Dictionary<Type, Func<object>> _typeFactories =
            new Dictionary<Type, Func<object>>();
    
        public ServiceLocator()
        {
            // register a factory method for each service
            _typeFactories[typeof(IWebService)] = () => new SomeWebService();
            _typeFactories[typeof(IVideoService)] = () => new SomeVideoService();
            
            // services can also be singletons, if they can be shared
            _typeFactories[typeof(IVoiceService)] = () => VoiceService.Instance;
        }
        
        public T GetService<T>()
        {
            // get the factory method and invoke it
            // (you will probably want to have some checks here)
            
            var factory = _typeFactories[typeof(T)];
            return factory();
        }
    }
   
