    public override void Up()
        {
            CreateTable(
                "dbo.NavigationMenus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Action = c.String(),
                        Controller = c.String(),
                        Icon = c.String(),
                        Selected = c.Boolean(nullable: false),
                        NavigationMenu_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NavigationMenus", t => t.NavigationMenu_Id)
                .Index(t => t.NavigationMenu_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NavigationMenus", "NavigationMenu_Id", "dbo.NavigationMenus");
            DropIndex("dbo.NavigationMenus", new[] { "NavigationMenu_Id" });
            DropTable("dbo.NavigationMenus");
        }
