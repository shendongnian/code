    var masterList = new List<string>
    {
        "Johnny", "Mark", "Tom", "Carl",
        "Jenny", "Susie", "Ben", "Tim", "Angie"            
    };
    var groupCount = 4; // Entered by the user
    var minGroupSize = masterList.Count / groupCount;
    var extraItems = masterList.Count % groupCount;
    var groupedNames = new List<List<string>>();
    for (int i = 0; i < groupCount; i++)
    {
        groupedNames.Add(masterList.Skip(i * minGroupSize).Take(minGroupSize).ToList());
        if (i < extraItems)
        {
            groupedNames[i].Add(masterList[masterList.Count - 1 - i]);
        }
    }
            
    Console.WriteLine("Here are the groups:");
    for(int index = 0; index < groupedNames.Count; index++)
    {
        Console.WriteLine($"#{index + 1}: {string.Join(", ", groupedNames[index])}");
    }
    Console.Write("\nDone!\nPress any key to exit...");
    Console.ReadKey();
