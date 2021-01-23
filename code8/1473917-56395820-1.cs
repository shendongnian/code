    services.AddSwaggerGen(c =>
                {
                    // Set Title and version
                    c.SwaggerDoc("v1", new Info { Title = "My Example API", Version = "v1", Description = "The API for my application" });
                    // Set the comments path for the Swagger JSON and UI.
                    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    // pick comments from classes
                    c.IncludeXmlComments(xmlPath);
                    // enable the annotations on Controller classes [SwaggerTag]
                    c.EnableAnnotations();
                });
