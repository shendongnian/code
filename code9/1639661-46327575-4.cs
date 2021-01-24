    Console.WriteLine("Would you like to print picture 1, 2, or 3?");
    int print = 0;
    string choice = "";
    while (choice != "end")
    {
        choice = Console.ReadLine().Trim();
        String thingToPrint = null;
        switch (choice)
        {
            case "1":
                thingToPrint = cocaCola;
                break;
            case "2":
                thingToPrint = beam;
                break;
            case "3":
                thingToPrint = liberty;
                break;
        }
        if (thingToPrint != null)
        {
            Console.WriteLine("How many times would you like to print it");
            print = Convert.ToInt32(Console.ReadLine());
            while (print > 0)
            {
                Console.WriteLine(thingToPrint);
                print -= 1;
            }
        }
        else
        {
            Console.WriteLine("You chose poorly. Try again.");
        }
        Console.WriteLine("Choose again, or type \"end\" to exit");
    }
