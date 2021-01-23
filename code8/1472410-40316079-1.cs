    string input = "all our vidphone lines here are trapped. they recirculate the call to other offices within the building";
    var queryList = new List<string> { "other", "they", "all", "building" };
    string[] stack = input.Split(' ').Select(s => s.Trim())
                                     .Where(s => s != string.Empty)
                                     .ToArray();
    foreach (var word in queryList)
    {
        for (int i = 0; i < stack.Length; i++)
        {
            if (word != stack[i]) continue;
            Console.WriteLine($"Found: {word}");
            Console.WriteLine(i > 0 ? $"Left: {stack[i-1]}" : "Left: (NONE)");
            Console.WriteLine(i < stack.Length - 1 ? $"Right: {stack[i+1]}" : "Right: (NONE)");
            Console.WriteLine();
        }
    }
    Console.ReadLine();
