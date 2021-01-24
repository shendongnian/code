        public void ConfigureServices( IServiceCollection services )
        {
                IServiceProvider serviceProvider = services.BuildServiceProvider();
                this.LoggerFactory.AddApplicationInsights( serviceProvider, Extensions.Logging.LogLevel.Information );
                ...
        }
