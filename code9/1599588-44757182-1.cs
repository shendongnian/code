    for (int j = 0; j < list.Count; j++)
    {
        int output = list.Where((val, idx) => idx != j).Aggregate((a, x) => a * x);
        Console.WriteLine(output);
    }
    Console.ReadKey();
