    public partial class Migration : DbMigration
    {
        public override void Up()
        {
            this.Sql("CREATE VIEW dbo.MyView AS (etc)");
        }
    
        public override void Down()
        {
            this.Sql("DROP VIEW dbo.MyView");
        }
    }
