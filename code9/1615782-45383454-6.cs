    // Order our results on 'BId' field           
    Console.WriteLine("\nHere are the results ordered by BId where status is 'OK':");
    int lastBid = 0;
    foreach (var item in items.Where(i => 
        i.Status.Equals("OK")).OrderByDescending(i => i.BId))
    {
        // Put a blank line between groups of BIds
        if (item.BId != lastBid)
        {
            Console.WriteLine();
            lastBid = item.BId;
        }
        Console.WriteLine(item);
    }
