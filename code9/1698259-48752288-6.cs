    public static class FilmProducerServiceExtensions
    {
        public static IServiceCollection AddFilmProducer(this IServiceCollection services, Action<IProducerOptions> options)
        {
            // Do additional service initialization
            return services;
        }
    }
