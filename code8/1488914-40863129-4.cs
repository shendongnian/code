    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.RegisterRepositoryServices();
            services.AddScoped<IRecruiterService, RecruiterService>();
            services.AddSingleton<IAccountService, AccountService>();
            return services;
        }
    }
