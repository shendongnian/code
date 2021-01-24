    public AppHost()
    {
        typeof(OpenApiService)
            .AddAttributes(new AuthenticateAttribute());
    }
