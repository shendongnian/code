    // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Car API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme { In = "header", Description = "description", Name = "Authorization", Type = "apiKey" });
                c.DescribeAllEnumsAsStrings();
                c.SchemaFilter<EnumFilter>();
            });
