    static void Main()
    {
        // Create our rules
        var statRules = new List<StatisticalRule>
        {
            new StatisticalRule {PercentGoal = 30, Value = 1},
            new StatisticalRule {PercentGoal = 40, Value = 2},
            new StatisticalRule {PercentGoal = 30, Value = 3},
        };
        // Get our 500 item stat list with rules applied
        var statList = GetStatisticalList(statRules, 500);
        // Display the statistics
        Console.WriteLine($"Our statistics list contains {statList.Count} items:");
        foreach (var uniqueValue in statList.Distinct())
        {
            var valueCount = statList.Count(i => i == uniqueValue);
            Console.WriteLine(" - Value: {0}, Count: {1}, Percent of Total: {2}%", 
                uniqueValue, valueCount, (double)valueCount / statList.Count * 100);
        }
        Console.Write("\nDone!\nPress any key to continue...");
        Console.ReadKey();
    }
