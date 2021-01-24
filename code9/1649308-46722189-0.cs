    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore()
                .AddAuthorization()
                .AddJsonFormatters();
    
            // Use default auth scheme (cookies)
            services.AddAuthentication(options => {
                     options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                     options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
                })
                .AddIdentityServerAuthentication("Bearer", options =>
                {
                    options.Authority = "http://localhost:5000";
                    options.RequireHttpsMetadata = false;
    
                    options.ApiName = "api1";
                    options.ApiSecret = "secret";
                });
    
                services.AddAuthorization(options =>
                {                
                    options.AddPolicy("ApiPolicy", policy =>
                    {
                       policy.AddAuthenticationSchemes("Bearer");
                       policy.RequireAuthenticatedUser();
                    });
                });
    
            // configure identity server with in-memory stores, keys, clients and scopes
            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryApiResources(Config.GetApiResources())
                .AddInMemoryClients(Config.GetClients());
        }
    
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
    
            //app.UseAuthentication();
            app.UseIdentityServer(); // does .UseAuthentication inside
            app.UseMvc();
        }
    }
