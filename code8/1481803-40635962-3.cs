            CreateTable(
                "dbo.MyUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Test = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MyUserProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        MyUser_Id = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MyUsers", t => t.Id)
                .ForeignKey("dbo.MyUsers", t => t.MyUser_Id)
                .Index(t => t.Id)
                .Index(t => t.MyUser_Id);
