    public class AuthenticationStrategy
    {
        private readonly IAuthenticationProviderResolver _resolver;
    
        public AuthenticationStrategy(IAuthenticationProviderResolver resolver)
        {
            if (resolver== null)
            {
                throw new ArgumentNullException("Provider Resolver");
            }
    
            _resolver = resolver;
        }
        public void MakeDecision()
        {
            _resolver.GetAuthByName(strategyName).Authenticate();
        }
    }
