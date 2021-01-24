    services.AddCors(options => options.AddPolicy("ApiCorsPolicy", builder =>
    {
        builder
            .AllowAnyOrigin()
            .WithHeaders(HeaderNames.AccessControlAllowHeaders, "Content-Type")
            .AllowAnyMethod()
            .AllowCredentials();
    }));
