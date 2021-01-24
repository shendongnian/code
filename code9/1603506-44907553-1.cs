    static void AddCoursesToStudent(SchoolDBContext context, Student student, List<int> CourseIds)
    {
        student.Courses = CourseIds.Select(id => context.Courses.Attach(new Course { CourseId = id })).ToList();
        context.SaveChanges();
    }
