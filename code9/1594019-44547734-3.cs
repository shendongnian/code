    var persons = GetObject<Person>();
    foreach (var item in persons)
    {
        Console.WriteLine($"{item.FirstName} {item.LastName}");
    }
    var employees = GetObject<Employee>();
    foreach (var item in employees)
    {
        Console.WriteLine($"{item.FirstName} {item.LastName}");
    }
