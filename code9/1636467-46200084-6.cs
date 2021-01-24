    using (var myDbContext = new MyDbContext(...))
    {
         IQueryable<Person> females = myDbcontext.Persons
            .Where(person => person.Gender == Gender.Female);
    }
