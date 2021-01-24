    services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "My Good API",
                        Version = "v1",
                        Description = "Doesn't hurt to add some description."
                    });
    
                    // Set the comments path for the Swagger JSON and UI.
                    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    c.IncludeXmlComments(xmlPath);
                });
