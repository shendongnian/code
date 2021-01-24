    foreach (var group in groupedList)
    {
        var groupMembers = group.ToList();
        Console.WriteLine($"Members who have a Start Date of: {group.Key:d}");
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine($" - {string.Join("\n - ", groupMembers)}");
        Console.WriteLine("\n");
    }
    
