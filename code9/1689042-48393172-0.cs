    static class MyLoggerEnrichmentConfigurationExtensions
    {
        public static LoggerConfiguration WithMyEnricher(this LoggerEnrichmentConfiguration enrich)
        {
            return enrich.With(new MyEnricher());
        }
    }
