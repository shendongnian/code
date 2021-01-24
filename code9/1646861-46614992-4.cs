       CreateTable(
                "dbo.Test1",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 500),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(),
                        DeleteDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedBy = c.Int(),
                        DeletedBy = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
