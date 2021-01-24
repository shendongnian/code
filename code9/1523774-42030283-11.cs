                Id = c.Int(nullable: false, identity: true),
                CollarColor = c.Int(nullable: false),
                Name = c.String(),
                Attributes_OwnerId = c.Int(),
            })
        .PrimaryKey(t => t.Id)
        .ForeignKey("dbo.PetAttributes", t => t.Attributes_OwnerId)
        .Index(t => t.Attributes_OwnerId);
