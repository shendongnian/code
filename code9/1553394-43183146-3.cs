    public class AuthenticationResolver : IAuthenticationResolver
        {
            private readonly IServiceProvider services;
            public AuthenticationResolver(IServiceProvider services)
            {
                this.services = services;
            }
    
            public IAuthenticationProvider GetProvider(Type type)
            {            
                return this.services.GetService(type) as IAuthenticationProvider;
            }
        }
