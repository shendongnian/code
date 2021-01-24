    Console.Write("Enter Selection: ");
    Console.TreatControlCAsInput = true;
    ConsoleKeyInfo selection = Console.ReadKey();    
    if (selection.Key == ConsoleKey.U)
    {
        Console.Write("Enter Another Value: ");
        string valueStr = Console.ReadLine();
        Console.WriteLine("You've entered {0}", valueStr);
    }
