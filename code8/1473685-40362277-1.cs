    var people = new List<Person>
    {
        new Person { Name = "A", LastName = "1", City = "B" },
        new Person { Name = "B", LastName = "3", City = "B" },
        new Person { Name = "C", LastName = "2", City = "B" },
    };
    
    var result = people.OrderBy(p => p.LastName);
