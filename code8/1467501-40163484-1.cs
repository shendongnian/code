            CreateTable(
                "dbo.EmployeeOptions",
                c => new
                    {
                        EmpId = c.Int(nullable: false),
                        Option1 = c.String(),
                        Option2 = c.String(),
                    })
                .PrimaryKey(t => t.EmpId)
                .ForeignKey("dbo.Employees", t => t.EmpId)
                .Index(t => t.EmpId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmpId = c.Int(nullable: false, identity: true),
                        FName = c.String(),
                        LName = c.String(),
                    })
                .PrimaryKey(t => t.EmpId);
