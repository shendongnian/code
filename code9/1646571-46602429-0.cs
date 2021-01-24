    public static class AddHealthApiExtensions
    {
        public static void AddHealthApi(this IMvcBuilder builder)
        {
            services.AddSingleton<HealthApiService>();
        }
    }
