    using System;
    using System.Data.Entity.Migrations;
    using System.IO;
    
    public partial class MigrationWithFileCopy : DbMigration
    {
        public override void Up()
        {
            File.Copy("sourceFile.jpg", "destinationFile.jpg");
        }
        
        public override void Down()
        {
            File.Delete("destinationFile.jpg");
        }
    }
