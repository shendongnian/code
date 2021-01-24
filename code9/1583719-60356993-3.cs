    // Startup.cs
    // ...
    services.AddSwaggerGen(options =>
    {
      options.SwaggerDoc("v1", new OpenApiInfo { Title = nameof(BoardMinutes), Version = "v1" });
      // Adds authentication to the generated json which is also picked up by swagger.
      options.AddSecurityDefinition(ApiKeyAuthenticationOptions.DefaultScheme, new OpenApiSecurityScheme
      {
          In = ParameterLocation.Header,
          Name = ApiKeyAuthenticationHandler.ApiKeyHeaderName,
          Type = SecuritySchemeType.ApiKey
      });
      options.OperationFilter<ApiKeyOperationFilter>();
    });
