    public IEnumerable<Courses> GetCoursesStudent(Int studentId)
    {
        var result = _dbContext
            .Enroll
            .Include(c => c.Courses)
            .Where(c => c.StudentId == studentId)
            .SelectMany(c => c.Courses)
            .ToList();
    }
