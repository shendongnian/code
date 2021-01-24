    var scores = new List<decimal>();
    Console.WriteLine("When entering grades, use a 0-4 scale. Remember:");
    Console.WriteLine("A = 4, B = 3, C = 2, D = 1, F = 0\n");
    
    Console.Write("Enter grade 1 (or 'X' to exit): ");
    var inValue = Console.ReadLine();
    while (inValue.ToUpper() != "X")
    {
        decimal input;
        if (!decimal.TryParse(inValue, out input) || input < 0 || input > 4)
        {
            Console.WriteLine("Invalid data; enter a number from 0 to 4, or 'X' to exit."); 
        }
        else
        {
            scores.Add(input);
        }
        Console.Write("Enter grade {0} (or 'X' to exit): ", scores.Count + 1);
        inValue = Console.ReadLine();
    }
    Console.WriteLine("The number of scores: " + scores.Count);
    Console.WriteLine("Your grade total is: " + scores.Sum());
    Console.WriteLine("Your GPA is: {0:0.00}", scores.Average());
    Console.ReadLine();
