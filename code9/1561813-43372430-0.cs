    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
       ...
       app.UseIdentityServerAuthentication(new IdentityServerAuthenticationOptions
       {
          Authority = "http://UrlOfIentityServer",
          RequireHttpsMetadata = false,
          ApiName = "exampleapi"
       });
       ...
    }
