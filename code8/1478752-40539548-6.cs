    static AirplaneSeating seating;
    static void Main(string[] args)
    {
        seating = new AirplaneSeating();
        Options();
    }
    static void Options()
    {
        bool optionOk = false;
        byte option = 0;
        while (!optionOk)
        {
            Console.Clear();
            Console.WriteLine("Select from the following menu:");
            Console.WriteLine("1. To Add Passenger");
            Console.WriteLine("2. To View Seating");
            Console.WriteLine("3. To View Passenger List");
            Console.WriteLine("4. Quit Application" + "\n");
            byte.TryParse(Console.ReadLine(), out option);
            if (option >= 1 && option <= 4)
            {
                optionOk = true;
            }
        }
        switch (option)
        {
            case 1:
                Console.Clear();
                seating.ReserveSeat();
                Console.WriteLine();
                Console.Write("Please press enter to return to main menu.");
                Console.ReadLine();
                Console.Clear();
                Options();
                break;
            case 2:
                Console.Clear();
                seating.PrintToConsole();
                Console.WriteLine();
                Console.Write("Please press enter to return to main menu.");
                Console.ReadLine();
                Console.Clear();
                Options();
                break;
            case 3:
                Console.Clear();
                seating.PrintPassengersToConsole();
                Console.WriteLine();
                Console.Write("Please press enter to return to main menu.");
                Console.ReadLine();
                Console.Clear();
                Options();
                break;
            case 4:
                Environment.Exit(0);
                break;
        }
    }
