    foreach (var exchange in exchanges)
    {
        services.AddTransient<Lazy<ITokenExchangeHandler>>(serviceProvider =>
        {
            return new Lazy<ITokenExchangeHandler>(() =>
            {
                var tokenExchangeHandler = serviceProvider.GetRequiredService<PipelineTokenExchangeHandler>();
                tokenExchangeHandler.Configure(exchange);
                return tokenExchangeHandler;
            });
        }); 
    }
    public static class AspNetCoreServiceCollectionExtensions
    {
        
        public static IServiceCollection AddLazyTransient<TService, TImplementation>(this IServiceCollection services)
            where TService : class
            where TImplementation : class, TService
        {
            services.AddTransient<TImplementation>();
            services.AddTransient<Lazy<TService>>(serviceProvider =>
            {
                return new Lazy<TService>(() =>
                {
                    var impl = serviceProvider.GetRequiredService<TImplementation>();
                    return impl;
                });
            });
            return services;
        }
       
    }
