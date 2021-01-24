    using (var dbContext = new MyLimitedContext(...))
    {
         var TeachersWithTheirStudents = dbContext.Teachers
             .Join(dbContext.Student)
             .GroupBy(teacher => teacher.Id,
                ...
    }
