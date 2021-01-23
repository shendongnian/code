    public override void Up()
    {
        CreateTable(
                "dbo.Images",
                c => new
                {
                    UserId = c.Guid(nullable: false)
                })
            .PrimaryKey(t => t.UserId)
            .ForeignKey("dbo.Users", t => t.UserId)
            .Index(t => t.UserId);
    
        CreateTable(
                "dbo.Users",
                c => new
                {
                    UserId = c.Guid(nullable: false)
                })
            .PrimaryKey(t => t.UserId);
    }
