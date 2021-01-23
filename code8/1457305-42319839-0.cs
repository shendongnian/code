        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "my api title",
                    Description = "my api desc",
                    TermsOfService = "None",
                    Contact = new Contact { Name = "contact" }
                });
                var filePath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "api.xml");
                c.IncludeXmlComments(filePath);
                c.AddSecurityDefinition("oauth2", new OAuth2Scheme
                {
                    Type = "oauth2",
                    Flow = "implicit",
                    AuthorizationUrl = "https://url",
                    Scopes = new Dictionary<string, string>
                        {
                            { "api-name", "my api" }
                        }
                });
            });
        }
    
        public void Configure(IApplicationBuilder app, ILoggerFactory    loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseIdentity();
            app.UseIdentityServerAuthentication(new IdentityServerAuthenticationOptions
            {
                Authority = "https://url",
                RequireHttpsMetadata = true,
                ApiName = "api-name",
                ApiSecret = "api-secret",
                AllowedScopes = { "api-name", "openid", "email", "profile" },
                ClaimsIssuer = "https://url",
                AutomaticAuthenticate = true,
            });
            app.UseStaticFiles();
            app.UseMvc();
            // Enable middleware to serve generated Swagger as a JSON endpoint
            app.UseSwagger();
            // Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
            app.UseSwaggerUi(c =>
            {
                c.ConfigureOAuth2("swagger-name", "swagger-secret", "swagger-realm", "Swagger");
            });
        }
