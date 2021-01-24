    Console.WriteLine("************************************");
    Console.WriteLine("Welcome to Bernard's Bodacious Bank!");
    Console.WriteLine("************************************");
    Console.WriteLine("We have opened your account");
    double amount = 0.0;
    ConsoleKeyInfo choice;
    do
    {
        DisplayMenu();
        choice = Console.ReadKey();
    } while (choice.Key != ConsoleKey.Q);
