    public override void Up()
    {
        DropForeignKey("dbo.GroupCourses", "Course_Id", "dbo.Courses");
        DropIndex("dbo.GroupCourses", new[] { "Course_Id" });
        DropPrimaryKey("dbo.Courses");
        DropPrimaryKey("dbo.GroupCourses");
        //Removed: AlterColumn("dbo.Courses", "Id", c => c.Int(nullable: false, identity: true));
        RenameColumn("dbo.Courses", "Id", "Id_Old"); //Added
        AddColumn("dbo.Courses", "Id", c => c.Int(nullable: false, identity: true)); //Added
        //Removed: AlterColumn("dbo.GroupCourses", "Course_Id", c => c.Int(nullable: false));
        RenameColumn("dbo.GroupCourses", "Course_Id", "Course_Id_Old"); //Added
        AddColumn("dbo.GroupCourses", "Course_Id", c => c.Int(nullable: false)); //Added
        Sql(@"UPDATE gc SET gc.Course_Id = c.Id " 
                + "FROM dbo.GroupCourses as gc " 
                + "INNER JOIN dbo.Courses as c ON gc.Course_Id_Old = c.id_Old"); //Added
        DropColumn("dbo.GroupCourses", "Course_Id_Old"); //Added
        DropColumn("dbo.Courses", "Id_Old");    //Added
        AddPrimaryKey("dbo.Courses", "Id");
        AddPrimaryKey("dbo.GroupCourses", new[] { "Group_Id", "Course_Id" });
        CreateIndex("dbo.GroupCourses", "Course_Id");
        AddForeignKey("dbo.GroupCourses", "Course_Id", "dbo.Courses", "Id", cascadeDelete: true);
    }
