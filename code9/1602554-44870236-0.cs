    // get all enrolments for Sutdent with certain Id
        var enrolments = context.Students
            .FirstOrDefault(s => s.ID == studentId)?.Enrollments?.ToList();
    
    // get all courses for a student
        var courses = context.Courses
            .Include(x => x.Enrollments)
            .SelectMany(c => c.Enrollments)
            .Where(e => e.StudentID == studentId)
            .ToList();
