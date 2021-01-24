    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_Blog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FeaturedPostId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.T_Post", t => t.FeaturedPostId)
                .Index(t => t.FeaturedPostId);
            
            CreateTable(
                "dbo.T_Post",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BlogId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.T_Blog", t => t.BlogId, cascadeDelete: true)
                .Index(t => t.BlogId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.T_Blog", "FeaturedPostId", "dbo.T_Post");
            DropForeignKey("dbo.T_Post", "BlogId", "dbo.T_Blog");
            DropIndex("dbo.T_Post", new[] { "BlogId" });
            DropIndex("dbo.T_Blog", new[] { "FeaturedPostId" });
            DropTable("dbo.T_Post");
            DropTable("dbo.T_Blog");
        }
    }
