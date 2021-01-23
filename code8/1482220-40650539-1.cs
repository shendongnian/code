    static void Main(string[] args)
    {
        var game = new Game();
        //May be some initialization logic       
        game.Run();
        Console.WriteLine("Press any key to restart, press Esc to close.");
        var userInput = Console.ReadKey();
        if (userInput.Key == ConsoleKey.Escape)
             return;
    }
