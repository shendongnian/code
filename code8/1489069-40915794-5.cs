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
