    IQueryable<Person> teachers = myDbcontext.Teachers.Cast<Person>();
    IQueryable<Person> students = myDbContext.Students.Cast<Person>();
    IQueryable<Person> allPersons = teachers.Concat(students);
    var result = allPersons.Where(person => ...)
         .Select(person => ...)
         ... etc
