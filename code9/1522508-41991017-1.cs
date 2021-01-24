    public abstract class ProviderSettings
    {
        protected abstract IProvider get_Provider();
        // there is no property setter
    }
    
    public class Settings : ProviderSettings
    {
        private readonly IProvider _provider;
    
        internal Settings(MyProvider provider) {
            _provider = provider; // assignment directly to backing field
            LoadFromConfig();
        }
    
        protected override IProvider get_Provider()
        {
            return _provider;
        }
        // there is no property setter
    }
