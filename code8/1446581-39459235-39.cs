    public partial class Accreditation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Accreditation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Accreditation");
        }
    }
