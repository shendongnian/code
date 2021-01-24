    public interface IAuthenticationProviderResolver
    {
        IAuthenticationProvider GetAuthByName(string name);
    }
    
    public class ProviderResolver : IAuthenticationProviderResolver
    {
        private readonly IServiceProvider _serviceProvider;
        public RepositoryResolver(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public IAuthenticationProvider GetAuthByName(string name)
        {
             if (name == "Internal") 
             {
                 return _serviceProvider.GetService<InternalAuthenticationProvider>();
             }
             else
             {
                 return _serviceProvider.GetService<ExternalAuthenticationProvider>();
             }
        }
    }
