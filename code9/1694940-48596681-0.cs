    protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentDetails");
            migrationBuilder.Sql(
                @"create proc GetStudentDetail
                @ssid int,
                @sectionId int = null
                as
                select Id, name, Gender, RollNumber, Status, Type,
                FatherName, FatherContact, SchoolClass, Section,
                SsId, SectionId, EnrollmentId
                from 
                (
                    SELECT stu.Id, stu.name, stu.Gender, en.RollNumber, en.Status, en.Type,
                    p.FatherName, p.FatherContact, sc.Name as SchoolClass, sec.Name as Section,
                    ss.SessionId as SsId, sec.Id as SectionId, en.Id as EnrollmentId,
                    en.EntryDate, row_number() over (partition by studentid order by en.entrydate desc) as rowno
                    from SchoolSessions ss
                    join SchoolClasses sc on ss.SessionId = sc.ssid
                    join Sections sec on sc.Id = sec.ClassId
                    join Enrollments en on sec.id = en.SectionId
                    join Students stu on en.StudentId = stu.Id
                    join parents p on stu.ParentId = p.Id 
                    where ss.SessionId = @ssid 
                ) A
                where rowno = 1 and
                (SectionId = @sectionId or @sectionId is null)"
                );
        }
