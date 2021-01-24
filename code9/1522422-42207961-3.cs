    CreateTable(
        "dbo.CloudObjects",
            c => new
                {
                    CloudObjectId = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    ParentId = c.Int(),
                    FileGroupId = c.Int(),
                    ETag = c.String(),
                    Discriminator = c.String(nullable: false, maxLength: 128),
                })
            .PrimaryKey(t => t.CloudObjectId)
            .ForeignKey("dbo.FileGroups", t => t.FileGroupId)
            .ForeignKey("dbo.CloudObjects", t => t.ParentId)
            .Index(t => t.ParentId)
            .Index(t => t.FileGroupId);
            
     CreateTable(
        "dbo.FileGroups",
            c => new
                {
                    FileGroupId = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                })
            .PrimaryKey(t => t.FileGroupId);
