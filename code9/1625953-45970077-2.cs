     services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new Info
                    {
                        Version = "v1",
                        Title = "ECommerce API",
                        Description = "",
                        TermsOfService = "None",
                        Contact = new Contact { Name = "", Email = "", Url = "" },
                        License = new License { Name = "", Url = "" }
                    });
    
                    //Set the comments path for the swagger json and ui.
                    var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                    var xmlPath = Path.Combine(basePath, "WebApi.xml");
                    c.IncludeXmlComments(xmlPath);
    
                    c.OperationFilter<AuthorizeCheckOperationFilter>();
    
                    c.AddSecurityDefinition("oauth2", new OAuth2Scheme
                    {
                        Type = "oauth2",
                        Flow = "implicit",
                        AuthorizationUrl = "http://localhost:5000/connect/authorize",
                        TokenUrl = "http://localhost:5000/connect/token",
                        Scopes = new Dictionary<string, string>()
                        {
                            { "api1", "My API" }
                        }
                    });
                });
