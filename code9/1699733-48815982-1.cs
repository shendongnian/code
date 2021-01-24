    private static void Main()
    {
        var myList = new List<string> {"dog", "cat", "dog", "bird"};
        var duplicates = myList.Where(item => myList.Count(i => i == item) > 1).ToList();
        for (var i = myList.Count - 1; i >= 0; i--)
        {
            var numDupes = duplicates.Count(item => item == myList[i]);
            if (numDupes <= 0) continue;
            duplicates.Remove(myList[i]);
            myList[i] += $" ({numDupes})";
        }
        Console.WriteLine(string.Join(", ", myList));
        Console.Write("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
