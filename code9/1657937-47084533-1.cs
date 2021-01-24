    using (var dbContext = new MyDbContext())
    {
        Student studentToRemove = ... 
        // for example:
        Student studentToRemove = dbContext.Students
             .Where(student => student.Name == "John Doe")
             .FirstOrDefault();
        if (studentToRemove != null)
        {
            dbContext.Students.Remove(studentToRemove);
            dbConext.SaveChanges();
        }
    }
