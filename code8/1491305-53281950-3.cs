    public partial class InitializeDb : DbMigration
    {
        public override void Up()
        {
                CreateTable(
                "dbo.Revision",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ...
                        IsReleased = c.Boolean(nullable: false, defaultValue: true),
                        ...
                    })
                .PrimaryKey(t => t.Id);
        }
    }
