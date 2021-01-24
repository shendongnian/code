    private static void DoWhatever(string data)
    {
        // process your temp
    }
    
    // inside main somewhere
    Console.WriteLine("Enter temp:");
    do
    {
        var temp = Console.ReadLine();
        DoWhatever(temp);
        Console.WriteLine("Continue? Press any key to continue, N or n to exit:\n");
    }while(Console.ReadKey().Key != ConsoleKey.N);
    Console.WriteLine("Thank you");
