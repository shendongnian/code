    public void ConfigureServices(IServiceCollection services)
    {
        services.AddAuthorization(o =>
        {
            //override the default policy
            o.DefaultPolicy =  new AuthorizationPolicy(new[] { new ClaimsAuthorizationRequirement(QueryStringAuthOptions.QueryStringAuthClaim, new string[0]) }, new[] { QueryStringAuthOptions.QueryStringAuthSchema });
    
            //or add a policy
            //o.AddPolicy("QueryKeyPolicy", options =>
            //{
            //    options.RequireClaim(QueryStringAuthOptions.QueryStringAuthClaim);
            //    options.AddAuthenticationSchemes(QueryStringAuthOptions.QueryStringAuthSchema);
            //});
    
        });
        services.AddAuthentication(o =>
        {
            o.SignInScheme = QueryStringAuthOptions.QueryStringAuthSchema;
        }); //adds the auth services
        services.AddMvc();
    }
