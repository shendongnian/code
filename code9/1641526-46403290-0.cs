    CreateTable(
        "dbo.People",
        c => new
            {
                Id = c.Int(nullable: false, identity: true),
                Name = c.String(),
            })
        .PrimaryKey(t => t.Id);
    
    CreateTable(
        "dbo.Cars",
        c => new
            {
                id = c.Int(nullable: false, identity: true),
                CarName = c.String(),
                Person_Id = c.Int(),
            })
        .PrimaryKey(t => t.id)
        .ForeignKey("dbo.People", t => t.Person_Id, cascadeDelete: true)
        .Index(t => t.Person_Id);
