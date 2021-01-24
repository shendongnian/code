                Id = c.Int(nullable: false, identity: true),
                Owner_OwnerId = c.Int(),
            })
        .PrimaryKey(t => t.Id)
        .ForeignKey("dbo.PetAttributes", t => t.Owner_OwnerId)
        .Index(t => t.Owner_OwnerId);
