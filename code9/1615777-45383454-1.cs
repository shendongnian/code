    /// <summary>
    /// Will return an item with the Id and Time for the items
    /// in the list that have the max Sum(Time) for that id
    /// </summary>
    /// <param name="input">A list of items to search</param>
    /// <returns>A new item representing the Id with the Max(Sum(Time))</returns>
    public static ColList GetIdWithMaxTime(List<ColList> input)
    {
        // Argument validation
        if (input == null || !input.Any())
        {
            throw new ArgumentException("The input list must contain at least one item");
        }
        // Group items by Id, and select new items with the 
        // 'Time' field set to the sum of those for that Id
        var inputGroupedById = input
            .GroupBy(item => item.Id)
            .Select(i => new ColList
            {
                Date = i.Max(item => item.Date),
                Id = i.Key,
                Time = i.Sum(item => item.Time),
                Talk = i.Sum(item => item.Talk),
                St = i.First().St
            })
            .ToList();
        // Return the first one whose Time equals the Max(Time)
        return inputGroupedById.First(i => i.Time == inputGroupedById.Max(g => g.Time));
    }
