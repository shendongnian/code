    var persons = new List<Person> {
          new Person { Name = "James", Age = 18, Male = true },
          new Person { Name = "Nicolas", Age = 52, Male = true },
          new Person { Name = "Susan", Age = 37, Male = false }
      };
    
    var result = persons.Aggregate(new Result(), (c, n) =>
    {
        c.Names.Add(n.Name);
        c.Age.Add(n.Age);
        c.Male.Add(n.Male);
        return c;
    });
