    String[] names = { "microsoft", "lg", "apple", "samsung" };
    string longestName = names.OrderByDescending(n => n.Length).FirstOrDefault();
    if (!String.IsNullOrEmpty(longestName))
    {
        Console.WriteLine("Longest name is {0} ({1} chars).", longestName, longestName.Length);
    }
    Console.ReadLine();
