    CreateTable("dbo.Table",
                c => new
                {
                    Id= c.Int(nullable: false, identity: true),
                    ...
                })
                .PrimaryKey(t => t.Id)
                ...
