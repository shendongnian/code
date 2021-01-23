    public override void Up()
    {
    	CreateTable(
    		"dbo.Lodgings",
    		c => new
    			{
    				LodgingId = c.Int(nullable: false, identity: true),
    				Name = c.String(nullable: false, maxLength: 200),
    				Owner = c.String(),
    				IsResort = c.Boolean(nullable: false),
    				MilesFromNearestAirport = c.Decimal(nullable: false, precision: 18, scale: 2),
    				Destination_DestinationId = c.Int(nullable: false),
    			})
    		.PrimaryKey(t => t.LodgingId)
    		.ForeignKey("dbo.Destinations", t => t.Destination_DestinationId, cascadeDelete: true)
    		.Index(t => t.Destination_DestinationId);
    	
    	CreateTable(
    		"dbo.Destinations",
    		c => new
    			{
    				DestinationId = c.Int(nullable: false, identity: true),
    				Name = c.String(nullable: false, maxLength: 100),
    				Country = c.String(),
    				Description = c.String(maxLength: 500),
    				Photo = c.Binary(storeType: "image"),
    			})
    		.PrimaryKey(t => t.DestinationId);
    	
    }
