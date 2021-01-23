    public override void Up()
    {
        CreateTable(
                "dbo.Users",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Email = c.String(),
                    UserName = c.String(),
                    Password = c.String(),
                    SecurityStamp = c.String()
                })
            .PrimaryKey(t => t.Id);
    }
