    bool? finalResult = null;
    bool input = false;
    
    Console.WriteLine("Are you Major?");
    
    if (bool.TryParse(Console.ReadLine(), out input))
        finalResult = input;
    }
