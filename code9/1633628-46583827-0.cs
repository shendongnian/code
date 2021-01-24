        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            if (Settings.Default.AllowAnonymous)
                      context.Principal = new AuthenticatedPrincipal(Thread.CurrentPrincipal);
        }
    
        public class AuthenticatedPrincipal : IPrincipal
        {
            private readonly IPrincipal principalToWrap;
    
            public AuthenticatedPrincipal(IPrincipal principalToWrap)
            {
                this.principalToWrap = principalToWrap;
                Identity = new AuthenticatedIdentity(principalToWrap.Identity);
            }
    
            public bool IsInRole(string role)
            { return principalToWrap.IsInRole(role); }
    
            public IIdentity Identity { get; }
        }
    
        public class AuthenticatedIdentity : IIdentity
        {
            public AuthenticatedIdentity(IIdentity identityToWrap)
            {
                Name = identityToWrap.Name;
                AuthenticationType = identityToWrap.AuthenticationType;
            }
    
            public string Name { get; }
            public string AuthenticationType { get; }
    
            public bool IsAuthenticated => true;
        }
