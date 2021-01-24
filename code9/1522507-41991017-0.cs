    public abstract class ProviderSettings
    {
        protected abstract IProvider get_Provider();
    }
    
    public class Settings : ProviderSettings
    {
        private readonly IProvider _provider;
    
        internal Settings(MyProvider provider) {
            _provider = provider;
            LoadFromConfig();
        }
    
        protected override IProvider get_Provider()
        {
            return _provider;
        }
    }
