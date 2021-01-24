    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Claims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        ClaimId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CommentDiscussions", t => t.ClaimId)
                .Index(t => t.ClaimId);
            CreateTable(
                "dbo.CommentDiscussions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaimId = c.Int(),
                        ForumThreadId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            CreateTable(
                "dbo.ForumThreads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        ForumThreadId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CommentDiscussions", t => t.ForumThreadId)
                .Index(t => t.ForumThreadId);
        }
        public override void Down()
        {
            DropForeignKey("dbo.ForumThreads", "ForumThreadId", "dbo.CommentDiscussions");
            DropForeignKey("dbo.Claims", "ClaimId", "dbo.CommentDiscussions");
            DropIndex("dbo.ForumThreads", new[] { "ForumThreadId" });
            DropIndex("dbo.Claims", new[] { "ClaimId" });
            DropTable("dbo.ForumThreads");
            DropTable("dbo.CommentDiscussions");
            DropTable("dbo.Claims");
        }
    }
