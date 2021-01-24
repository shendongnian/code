    public class CustomIdentity : ClaimsIdentity
    {
        // Must set an authentication type for IsAuthenticated to be true
        public CustomIdentity(string authenticationType) : base(authenticationType) {}
        // ...
    }
