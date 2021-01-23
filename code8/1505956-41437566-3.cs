    DateTime birthday;
    // error handling similar to the following (if-clause work fine to)
    while(!DateTime.TryParse(Console.ReadLine())) 
    {
        Console.WriteLine("Invalid input, try again.");
    }
