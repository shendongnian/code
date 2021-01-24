    static class MyDbContextExtensions
    {
        IQueryable<Person> Persons(this MyDbContext dbContext)
        {
            return dbContext.Teachers.Cast<Person>()
                .Concat(dbContext.Students.Cast<Person>());
        }
    }
