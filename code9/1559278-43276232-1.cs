    public sealed class CustomAuthenticationAttribute : IAsyncAuthorizationFilter 
    {
        private readonly IPrivateKeyLookupService keyService;
        public CustomAuthenticationAttribute(
            IPrivateKeyLookupService keyService)
        {
            this.keyService = keyService;
        }
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            ...
        }
    }
