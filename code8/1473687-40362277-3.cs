    var people = new List<Person>
    {
        new Person { Name = "A", LastName = "1", City = "B" },
        new Person { Name = "B", LastName = "3", City = "B" },
        new Person { Name = "C", LastName = "2", City = "B" },
    };
    
    //Linq OrderBy:
    var result = people.OrderBy(p => p.LastName);
    //List Sort:
    people.Sort((x, y) => string.Compare(x.LastName, y.LastName));
