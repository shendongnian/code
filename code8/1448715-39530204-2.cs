    public interface IDataService 
    {
        void AddData(...);
    }
    
    public interface IServiceLocator
    {
        IDataService GetServiceByName(string name);
    }
    
    public class ServiceLocator : IServiceLocator
    {
        readonly Dictionary<string, Func<IDataService>> _typeFactories = 
            new Dictionary<string, Func<IDataService>>();
    
        public ServiceLocator()
        {
            _typeFactories["WEB"] = () => new SomeWebService();
            _typeFactories["VIDEO"] = () => new SomeVideoService();
            _typeFactories["VOICE"] = () => SomeVoiceService.Instance; // singleton            
        }
        
        public IDataService GetServiceByName(string name)
        {
            var factory = _typeFactories[name];
            return factory();
        }
    }
