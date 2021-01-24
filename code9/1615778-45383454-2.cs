    /// <summary>
    /// Will a list of all items grouped by the Id, 
    /// with a Sum of the Time and Talk fields
    /// </summary>
    /// <param name="input">A list of items to search</param>
    /// <returns>A new item representing the Id with the Max(Sum(Time))</returns>
    public static List<ColList> GroupItemsOnId(List<ColList> input)
    {
        // Argument validation
        if (input == null || !input.Any())
        {
            throw new ArgumentException("The input list must contain at least one item");
        }
        // Group items by Id, and select new items with the 
        // 'Time' field set to the sum of those for that Id
        return input
            .GroupBy(item => item.Id)
            .Select(i => new ColList
            {
                Date = i.Max(item => item.Date),
                Id = i.Key,
                Time = i.Sum(item => item.Time),
                Talk = i.Sum(item => item.Talk),
                Status = i.First().Status
            })
            .ToList();
    }
