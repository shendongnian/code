    public static IMvcBuilder AddJsonOptions(
        this IMvcBuilder builder,
        Action<MvcJsonOptions> setupAction)
    {
        if (builder == null)
        {
            throw new ArgumentNullException(nameof(builder));
        }
        if (setupAction == null)
        {
            throw new ArgumentNullException(nameof(setupAction));
        }
        // configure registers it with the DI system
        builder.Services.Configure(setupAction);
        return builder;
    }
