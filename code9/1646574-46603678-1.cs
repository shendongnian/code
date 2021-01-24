    public static class ServiceCollectionExtensions
    {
        public static void AddHealthApi(this IServiceCollection services, Func<HealthApiServiceBuilder, HealthApiServiceBuilder> expression)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (expression == null)
                throw new ArgumentNullException(nameof(expression));
            var starter = new HealthApiServiceBuilder();
            var builder = expression(starter);
            services.AddSingleton<IHealthApiService>(builder.Build());
        }
        public static void AddHealthApi(this IServiceCollection services)
        {
            AddHealthApi(services, builder => { return builder; });
        }
    }
