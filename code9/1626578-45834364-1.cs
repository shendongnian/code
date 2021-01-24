     public override void Up()
            {
                CreateTable(
                    "dbo.ExchangeStudent",
                    c => new
                        {
                            ExchangeStudentId = c.Int(nullable: false, identity: true),
                            HomeUniversity = c.String(),
                            Student_StudentId = c.Int(),
                        })
                    .PrimaryKey(t => t.ExchangeStudentId)
                    .ForeignKey("dbo.Student", t => t.Student_StudentId)
                    .Index(t => t.Student_StudentId);
                
                CreateTable(
                    "dbo.Student",
                    c => new
                        {
                            StudentId = c.Int(nullable: false, identity: true),
                            Nickname = c.String(),
                            Name = c.String(),
                        })
                    .PrimaryKey(t => t.StudentId);
                
            }
