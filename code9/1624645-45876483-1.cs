    public class Startup
    {
        private IServiceCollection _serviceCollection;
        public void ConfigureServices(IServiceCollection services)
        {
            _serviceCollection = services; // Hacky way to access services in other methods :s
            // services.AddStuff() down here, including the AzureAD OIDC
        }
        private async Task TokenValidated(TokenValidatedContext context)
        {
            IRoleClaims roleClaims; // My class for reading from services/database
                                    // and create claims
            // This is the magic DI workaround I was looking for
            var scopeFactory = _serviceCollection.BuildServiceProvider()
                               .GetRequiredService<IServiceScopeFactory>();
            using (var scope = scopeFactory.CreateScope())
            {
                var provider = scope.ServiceProvider;
                roleClaims = provider.GetRequiredService<IRoleClaims>();
            }
            // Getting the ObjectID for the user from AzureAD
            var objectId = context.SecurityToken.Claims
                .Where(o => o.Type == "oid")
                .Select(o => o.Value)
                .SingleOrDefault();
            var claims = await roleClaims.CreateRoleClaimsForUser(objectId);
            context.Principal.AddIdentity(new ClaimsIdentity(claims));
        }
        // Rest of the methods not shown
    }
