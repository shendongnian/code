    int totalCost = 0;
    bool buyAnotherOne;
    do
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("What size coffee would you like? (1-Small, 2-Medium, 3-Large)?");
        int response;
        do
        {
            Console.Write(" - Enter a number from 1 - 3: ");
        } while (!int.TryParse(Console.ReadLine(), out response)
                 || response < 1 || response > 3);
        switch (response)
        {
            case 1:
                totalCost += 50;
                break;
            case 2:
                totalCost += 70;
                break;
            case 3:
                totalCost += 100;
                break;
        }
        Console.Write("Do You want to buy another coffee (yes or no): ");
        buyAnotherOne = Console.ReadLine().StartsWith("y",
            StringComparison.OrdinalIgnoreCase);
    } while (buyAnotherOne);
    Console.WriteLine("Thank you for shopping with us");
    Console.WriteLine("Your bill is genrating; please wait...");
    Thread.Sleep(TimeSpan.FromSeconds(3));
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("Your total bill: {0}", totalCost);
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("\nDone!\nPress any key to exit...");
    Console.ReadKey();
