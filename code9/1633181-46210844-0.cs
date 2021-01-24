    public void ConfigureServices(IServiceCollection services)
{
   
          services.Configure<JwtSettings>(Configuration.GetSection("jwt"));
          var provider = services.BuildServiceProvider();     
          var jwtSettings = provider.GetService<JwtSettings>();
           
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(o =>
                {                                   
                    o.TokenValidationParameters = new TokenValidationParameters
                    {                        
                        ValidateIssuer = jwtSettings.Issuer;
                        ValidateAudience = false,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key)) // some secret Key
                        
                    };                   
                  
                });
    }
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
     ....
      app.UseAuthentication();
      app.UseMvc();
    }
