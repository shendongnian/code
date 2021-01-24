    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 1000),
                        IsDeleted = c.Boolean(nullable: false),
                        IsApproved = c.Boolean(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CategoryTrans",
                c => new
                    {
                        CategoryId = c.Int(nullable: false),
                        LanguageId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => new { t.CategoryId, t.LanguageId })
                .ForeignKey("dbo.Languages", t => t.LanguageId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.LanguageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.CategoryTrans", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.CategoryTrans", "LanguageId", "dbo.Languages");
            DropIndex("dbo.CategoryTrans", new[] { "LanguageId" });
            DropIndex("dbo.CategoryTrans", new[] { "CategoryId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropTable("dbo.CategoryTrans");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.Languages");
        }
    }
