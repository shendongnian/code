    public enum AuthType
    {
        Internal,
        External,
    }
    public interface IAuthenticationProviderResolver
    {
        IAuthenticationProvider GetAuthByType(AuthType type);
    }
    public class ProviderResolver : IAuthenticationProviderResolver
    {
        private readonly IServiceProvider _serviceProvider;
        public RepositoryResolver(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public IAuthenticationProvider GetAuthByName(AuthType type)
        {
             switch (type) 
             {
                 case AuthType.Internal:
                     return _serviceProvider.GetService<InternalAuthenticationProvider>();
                 case AuthType.External:
                     return _serviceProvider.GetService<ExternalAuthenticationProvider>();
                 default:
                     throw new ArgumentException("Unknown type for authentication", nameof(type))
             }
        }
    }
