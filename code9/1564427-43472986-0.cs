    List<long> userInts = new List<long>();
    for (int i = 0; i < 99; i++)
    {
        string userValue = Console.ReadLine();
    
        if (userValue.Contains("End"))
            break;
    
        int userInt;
    
        if (int.TryParse(userValue, out userInt))
            userInts.Add(userInt);
    
    }
    
    // Print the unchanged numbers
    Console.WriteLine("De originele opsteling van nummers:");
    foreach (long numb in userInts)
        Console.Write("    {0}", numb);
    
    Console.WriteLine(Environment.NewLine);
    // Sorts the List
    userInts.Sort();
    
    // Output the sorted list
    Console.WriteLine("Lijst in gesorteerde ordening:  ");
    foreach (long numb in userInts)
        Console.Write("    {0}", numb);
    
    Console.WriteLine();
    Console.ReadKey();
