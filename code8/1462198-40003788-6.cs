            CreateTable(
                "dbo.UserRoleAccesses",
                c => new
                    {
                        UserRoleAccessId = c.Long(nullable: false, identity: true),
                        UserRoleId = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        Name = c.String(),
                        UserRoleAccessType = c.Int(nullable: false),
                        ApplicationRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserRoleAccessId)
                .ForeignKey("dbo.AspNetRoles", t => t.ApplicationRole_Id)
                .Index(t => t.ApplicationRole_Id);
