    private static void Main()
    {
        var myList = new List<string> { "dog", "cat", "dog", "bird" };
        var formattedItems = new List<string>();
        foreach (var item in myList)
        {
            if (myList.Count(i => i == item) > 1)
            {
                int counter = 1;
                while (formattedItems.Contains($"{item} ({counter})")) counter++;
                formattedItems.Add($"{item} ({counter})");
            }
            else
            {
                formattedItems.Add(item);
            }
        }
        Console.WriteLine(string.Join(", ", formattedItems));
        Console.Write("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
