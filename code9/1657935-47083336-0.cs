    var course = context.Courses.Include(c => c.Students)
        .SingleOrDefault(c => c.CourseID == selectedCourseId);
    if (course != null)
    {
        var studentToRemove = course.Students.SingleOrDefault(s => c.StudentID == selectedStudentId);
        if (studentToRemove != null)
        {
            course.Students.Remove(studentToRemove);
            context.SaveChanges();
        }
    }
