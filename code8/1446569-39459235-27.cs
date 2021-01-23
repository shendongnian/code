    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Buildings",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Location = c.String(),
                        User_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Buildings", "User_Id", "dbo.Users");
            DropIndex("dbo.Buildings", new[] { "User_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Buildings");
        }
    }
