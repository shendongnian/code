    public static class AddHealthApiExtensions
    {
        public static void AddHealthApi(this IServiceCollection services)
        {
            services.AddSingleton<HealthApiService>();
        }
    }
