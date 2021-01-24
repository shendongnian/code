    CreateTable(
        "dbo.BaseWidget",
        c => new
            {
                Id = c.Int(nullable: false, identity: true),
            })
        .PrimaryKey(t => t.Id);
    
    CreateTable(
        "dbo.ExistingWidget",
        c => new
            {
                Id = c.Int(nullable: false),
            })
        .PrimaryKey(t => t.Id)
        .ForeignKey("dbo.BaseWidget", t => t.Id)
        .Index(t => t.Id);
    
    CreateTable(
        "dbo.NewWidgetBase",
        c => new
            {
                Id = c.Int(nullable: false),
                EmployeeNumber = c.Int(nullable: false),
                EffectiveDate = c.DateTime(nullable: false),
                Discriminator = c.String(nullable: false, maxLength: 128),
            })
        .PrimaryKey(t => t.Id)
        .ForeignKey("dbo.BaseWidget", t => t.Id)
        .Index(t => t.Id);
    
    CreateTable(
        "dbo.FooDetails",
        c => new
            {
                Id = c.Int(nullable: false),
                Data = c.String(),
            })
        .PrimaryKey(t => t.Id)
        .ForeignKey("dbo.NewWidgetBase", t => t.Id)
        .Index(t => t.Id);
    
    CreateTable(
        "dbo.BarDetails",
        c => new
            {
                Id = c.Int(nullable: false),
                Data = c.String(),
            })
        .PrimaryKey(t => t.Id)
        .ForeignKey("dbo.NewWidgetBase", t => t.Id)
        .Index(t => t.Id);
            
