    private static void Main()
    {
        var filePath = @"f:\public\temp\temp.txt";
        var foodItems = new List<FoodItem>();
        foreach (var fileLine in File.ReadAllLines(filePath))
        {
            foodItems.Add(FoodItem.CreateFromCommaString(fileLine));
        }
        var sortedItems = foodItems
            .OrderBy(item => item.FoodCategory)
            .ThenBy(item => item.FoodType)
            .ThenBy(item => item.Price)
            .ToList();
        sortedItems.ForEach(Console.WriteLine);
        Console.Write("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
