    public void ConfigureServices(IServiceCollection services)
    {
        // ...
        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o => {
                o.Audience = Configuration.GetSection("jwt:Audience").Value;
                o.Authority = Configuration.GetSection("jwt:Authority").Value;
                o.RequireHttpsMetadata = Configuration.GetValue<bool>("jwt:RequireHttps");
                o.Events = new JwtBearerEvents()
                {
                    OnAuthenticationFailed = c =>
                    {
                        c.NoResult();
                        c.Response.StatusCode = 401;
                        return c.Response.WriteAsync("Invalid Token");
                    }
                };
            });
    }
    
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // ...
            app.UseAuthentication();
            // ...
            app.UseMvc();
        }
