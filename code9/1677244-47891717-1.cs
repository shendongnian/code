    List<Person> persons = new List<Person>{
    	new Person{ PersonID = 13,  PersonName = "Foo" },
    	new Person{ PersonID = 13,  PersonName = "Foo" },
    	new Person{ PersonID = 15,  PersonName = "Foo" }
    };
    
    var grp = persons.GroupBy(p => p.PersonID)
        .Select(p => new {pid = p.Key, count = p.Count()});
    
    foreach (var element in grp)
    {
    	Console.WriteLine($"PersonID = {element.pid}, Count of Person = {element.count}");
    }
