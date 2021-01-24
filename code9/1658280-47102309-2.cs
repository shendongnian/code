    public AppHost()
    {
        typeof(SwaggerResource)
            .AddAttributes(new AuthenticateAttribute());
        typeof(SwaggerResources)
            .AddAttributes(new AuthenticateAttribute());
    }
