    internal sealed class Configuration : DbMigrationsConfiguration<MyBaseContext>
    {
        private readonly ILogger _logger;
    
        public Configuration(ILoggerFactory loggerFactory)
        {
            this._logger = loggerFactory.CreateLogger<Configuration>();
            AutomaticMigrationsEnabled = true;
        }
    
        protected override void Seed(Home.DAL.Data.HomeBaseContext context)
        {
             //log something
             _logger.LogInformation(1, "Seeding data.");
        }
    }
