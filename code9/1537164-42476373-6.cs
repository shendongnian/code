    public override void Up()
    {
            CreateTable(
                "dbo.TeacherEFs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentEFs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TeacherEFStudentEFs",
                c => new
                    {
                        TeacherEF_Id = c.Int(nullable: false),
                        StudentEF_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TeacherEF_Id, t.StudentEF_Id })
                .ForeignKey("dbo.TeacherEFs", t => t.TeacherEF_Id, cascadeDelete: true)
                .ForeignKey("dbo.StudentEFs", t => t.StudentEF_Id, cascadeDelete: true)
                .Index(t => t.TeacherEF_Id)
                .Index(t => t.StudentEF_Id);
            
            CreateTable(
                "dbo.TeachersStudents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeacherId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => new { t.TeacherId, t.StudentId }, name: "IX_Teacher_Student");
    }
