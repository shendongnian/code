    public static IMvcBuilder AddRequestFilter(this IMvcBuilder builder)
    {
        builder.Services.Configure<MvcOptions>(options =>
        {
            options.Filters.Add(typeof(RequestFilter));
        });
        return builder;
    }
