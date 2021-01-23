    public class SomeClass
    {
        public SomeClass(IAuthenticationServiceGetter _authenticationServiceGetter)
        {
            var authenticationService = _authenticationServiceGetter.GetAuthenticationService();
        }
    }
