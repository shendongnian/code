    internal sealed class Configuration : DbMigrationsConfiguration<MyBaseContext>
    {
        private readonly ILogger _logger;
    
        public Configuration(ILoggerFactory loggerFactory)
        {
            this._logger = loggerFactory.Create("ConfigurationLogger");
            AutomaticMigrationsEnabled = true;
        }
    
        protected override void Seed(Home.DAL.Data.HomeBaseContext context)
        {
             //log something
             _logger.LogInformation(1, "Seeding data.");
        }
    }
    public partial class InitialMigration : DbMigration
    {        
        private readonly ILogger _logger;
    
        public InitialMigration(ILoggerFactory loggerFactory)
        {            
             this._logger = loggerFactory.Create("InitialMigrationLogger");
        }
    
        public override void Up()
        {
            _logger.WriteInformation("Create table.");
            CreateTable(...);
        }
    
        public override void Down()
        {
            _logger.WriteInformation("Drop table.");
            DropTable(...);
        }
    }
