    public static class FilmProducerServiceExtensions
    {
        public static IServiceCollection AddFilmProducer(this IServiceCollection services, Action<ProducerOptions> options)
        {
            // Create your delegate
            var producerOptions = new ProducerOptions();
            options(producerOptions);
            // Do additional service initialization
            return services;
        }
    }
