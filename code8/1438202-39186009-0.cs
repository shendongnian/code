    public static class ServiceCollectionExtensions
    {
     public static IServiceCollection RegisterServices(
        this IServiceCollection services)
    {
        services.AddTransient<ICountryService, CountryService>();
        // and a lot more Services
        return services;
    }
