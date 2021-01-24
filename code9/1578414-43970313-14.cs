    static void Main()
    {
        bool exit = false;
        Console.WriteLine("Please choose an option:");
        Console.WriteLine("1. Enter a new reader");
        Console.WriteLine("2. Enter a new book");
        Console.WriteLine("3. Service the next borrower");
        Console.WriteLine("4. Service the next returner");
        Console.WriteLine("5. Exit the program");
        while (!exit)
        {
            Console.Write("\nEnter choice (1-5): ");
            int input;
            while (!int.TryParse(Console.ReadLine(), out input) || input < 1 || input > 5)
            {
                Console.Write("Invalid input. Enter a number from 1-5: ");
            }
            switch(input)
            {
                case 1:
                    Lineup();
                    break;
                case 2:
                    Add();
                    break;
                case 3:
                    ServiceBorrower();
                    break;
                case 4:
                    ServiceReturner();
                    break;
                case 5:
                    exit = true;
                    break;
            }
        }
        Console.Write("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
