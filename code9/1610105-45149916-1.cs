    public class MyPrincipal : IPrincipal
    {
        public IIdentity Identity => new MyIdentity();
        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }
    }
    public class MyIdentity : IIdentity
    {
        public string Name => throw new NotImplementedException();
        public string AuthenticationType => throw new NotImplementedException();
        public bool IsAuthenticated => throw new NotImplementedException();
    }
