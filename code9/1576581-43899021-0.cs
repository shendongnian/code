    private static void Main()
    {
        Console.Title = "5";
        Console.ForegroundColor = ConsoleColor.Blue;
        List<string> outerCompartment = new List<string>();
        List<string> mainCompartment = new List<string>();
        bool allDone = false;
        while (!allDone)
        {
            Console.WriteLine("\nThis is your bag!");
            Console.WriteLine("[1] to pack things in the main compartment");
            Console.WriteLine("[2] to pack things in the outer compartment");
            Console.WriteLine("[3] to see packed things");
            Console.WriteLine("[4] to quit");
            Console.WriteLine("Please enter your choice: ");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
            {
                Console.WriteLine("Invalid input. Enter a number from 1 to 4: ");
            }
            switch (choice)
            {
                case 1:
                    GetItemsAndAddToCompartment(mainCompartment, "main");
                    Console.Clear();
                    break;
                case 2:
                    GetItemsAndAddToCompartment(outerCompartment, "outer");
                    Console.Clear();
                    break;
                case 3:
                    DisplayBagContents(mainCompartment, outerCompartment);
                    break;
                case 4:
                    Console.WriteLine("All done. Have a great trip!");
                    allDone = true;
                    break;
            }
        }
        Console.WriteLine("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
