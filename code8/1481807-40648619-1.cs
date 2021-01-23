    public override void Up()
    {
        CreateTable(
            "dbo.MyUserProfiles",
            c => new
                {
                    Id = c.Int(nullable: false),
                    FirstName = c.String(),
                    LastName = c.String(),
                })
            .PrimaryKey(t => t.Id)
            .ForeignKey("dbo.MyUsers", t => t.Id)
            .Index(t => t.Id);
            
        CreateTable(
            "dbo.MyUsers",
            c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                })
            .PrimaryKey(t => t.Id);
    }
