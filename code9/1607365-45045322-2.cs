    var newlist = new List<SP>
    {
        new SP {ID = 1, Name = "one", StartDate = DateTime.Today.AddDays(-1),
            EndDate = DateTime.Today},
        new SP {ID = 2, Name = "two", StartDate = DateTime.Today.AddDays(-2),
            EndDate = DateTime.Today},
        new SP {ID = 3, Name = "three", StartDate = DateTime.Today.AddDays(-3),
            EndDate = DateTime.Today},
        new SP {ID = 4, Name = "four", StartDate = DateTime.Today.AddDays(-1),
            EndDate = DateTime.Today},
        new SP {ID = 5, Name = "five", StartDate = DateTime.Today.AddDays(-2),
            EndDate = DateTime.Today},
        new SP {ID = 6, Name = "six", StartDate = DateTime.Today.AddDays(-3),
            EndDate = DateTime.Today},
    };
    // Filter and Group on Property 'StartDate'
    var groupedList = newlist
        .Where(a => a.StartDate > DateTime.Today.AddDays(-3))
        .GroupBy(a => a.StartDate).ToList();
    Console.WriteLine($"Filtering on StartDate > '{DateTime.Today.AddDays(-1)}':");
    foreach (var item in groupedList)
    {
        Console.WriteLine($"Group start date = {item.Key}");
        Console.WriteLine($" - Sum of ID is: {item.Sum(i => i.ID)}");
        Console.WriteLine($" - Names are: {string.Join(", ", item.Select(i => i.Name))}\n");
    }
    // Wait for input before closing
    Console.WriteLine("\nDone!\nPress any key to exit...");
    Console.ReadKey();
    
