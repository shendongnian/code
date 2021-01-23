    public class SomeClass
    {
        public SomeClass(IAuthenticationServiceFactory _authenticationServiceFactory)
        {
            var authenticationService = _authenticationServiceFactory.GetAuthenticationService();
        }
    }
