    Console.WriteLine("What would you like to search for (Title: Full Title; Author: first, last): ");
    search = Console.ReadLine();
    var results = bookList.Where(x => x.Contains(search)).ToList();
    if (results != null)
    {
        foreach (var result in results)
        {
            Console.WriteLine(result);
        }
        Console.WriteLine("Press Enter to continue");
        Console.ReadLine();
    }
