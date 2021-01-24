    Console.WriteLine("Here are the items sorted by Time, followed by the times the Id repeated:");
    foreach (var item in groupedItems.OrderByDescending(i => i.Time))
    {
        // Get the count of this id, and if it was repeated more than once color the text green
        var countOfThisId = items.Count(i => i.Id == item.Id);
        var consoleColor = countOfThisId > 1 ? ConsoleColor.Green : Console.ForegroundColor;
        Console.ForegroundColor = consoleColor;
        Console.WriteLine($"{item}\tId was repeated {countOfThisId} times.");
        Console.ResetColor();
    }
    Console.WriteLine("\nHere are the items sorted by Talk:");
    foreach (var item in groupedItems.OrderByDescending(i => i.Talk))
    {
        Console.WriteLine(item);
    }
