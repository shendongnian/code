                Id = c.Int(nullable: false, identity: true),
                Name = c.String(),
                Attributes_OwnerId = c.Int(),
            })
        .PrimaryKey(t => t.Id)
        .ForeignKey("dbo.PetAttributes", t => t.Attributes_OwnerId)
        .Index(t => t.Attributes_OwnerId);
