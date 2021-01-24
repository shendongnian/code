    private static void Main()
    {
        // Create a parent list with two child lists
        // The first one will track numbers divisible by 11
        // The second one will track numbers divisible by 13
        var parentList = new List<List<int>>
        {
            new List<int>(),
            new List<int>()
        };
        var rnd = new Random();
        for (int i = 0; i < 1000; i++)
        {
            // Generate a random number
            var randomNumber = rnd.Next(1, 501);
            if (randomNumber % 11 == 0)
            {
                parentList[0].Add(randomNumber);
            }
            if (randomNumber % 13 == 0)
            {
                parentList[1].Add(randomNumber);
            }
        }
        Console.WriteLine("Here is a comparison of the list counts:");
        Console.WriteLine($"Numbers divisible by 11: {parentList[0].Count}");
        Console.WriteLine($"Numbers divisible by 13: {parentList[1].Count}");            
        Console.Write("\nDone!\nPress any key to quit.");
        Console.ReadKey();
    }
