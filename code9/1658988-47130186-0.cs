    private static void DoWhatever(string data)
    {
        // process your temp
    }
    
    // inside main somewhere
    Console.WriteLine("Enter temp:");
    ConsoleKey key;
    do
    {
        var temp = Console.ReadLine();
        DoWhatever(temp);
        Console.WriteLine("Continue? Press any key to continue, N or n to exit:\n");
        key = Console.ReadKey();
    }while(key.Key != ConsoleKey.N && key.Key != ConsoleKey.n);
    Console.WriteLine("Thank you");
