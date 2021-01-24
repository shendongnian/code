    Console.WriteLine("Low Numbers");
    foreach (int x in intList.Except(intList.Where(isHighNUmber)).ToList<int>())
    {
        Console.WriteLine(x);
    }
