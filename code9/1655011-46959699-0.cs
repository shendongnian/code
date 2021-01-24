    public static void RegisterRequestFilter(this IServiceCollection services)
    {
        services.Configure<MvcOptions>(options =>
        {
            options.Filters.Add(typeof(RequestFilter));
        });
    }
