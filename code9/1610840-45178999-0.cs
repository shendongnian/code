    foreach(var group in groups.OrderBy(g => g.Key.Gender).ThenBy(g => g.Key.Country))
    {
        Console.WriteLine($"{group.Key.Gender} sub list {group.Key.Country}");
        foreach(var person in group)
            Console.WriteLine(person.Name);
    }
