    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                             .RequireAuthenticatedUser()
                             .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });
    
            //other code ...
        }
    
        //other code ...
    }
