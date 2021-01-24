    var ids = new string[] {"AF1", "AF2", "AF3"};
    var persons = new Person[]
    {
        new Person("AF1", "John", 20),
        new Person("AF1", "Oscar", 50),
        new Person("AF2", "Peter", 30),
        new Person("AF2", "Abbey", 65),
        new Person("AF3", "Adrian", 43),
        new Person("AF3", "Barbara", 15)
    };
    var groups = persons.Where(p => ids.Contains(p.PersonId)).GroupBy(p => p.PersonId);
    foreach (var group in groups)
    {
        Console.WriteLine(group.Key + ": " + group.Sum(p => p.Age));
    }
