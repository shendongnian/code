    public partial class InitialMigration : DbMigration
    {        
        private readonly ILogger _logger;
    
        public InitialMigration(ILoggerFactory loggerFactory)
        {            
             this._logger = loggerFactory.CreateLogger<ManageController>();
        }
    
        public override void Up()
        {
            _logger.LogInformation(1, "Create table.");
            CreateTable(...);
        }
    
        public override void Down()
        {
            _logger.LogInformation(1, "Drop table.");
            DropTable(...);
        }
    }
