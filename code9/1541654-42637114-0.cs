    Console.Clear();
    string choice;
    
    Console.WriteLine("Welcome to Costa coffee\n");
    Console.WriteLine("1:> Latte\n2:> Cappuccino\n3:> Espresso\n4:> Double espresso");
    Console.WriteLine("\nPlease select a coffee by pressing 1-4");
    choice = Console.ReadLine();
    
    
    if (choice == "1")
    {
        Console.WriteLine("\nYou have selected: latte");
    }
    else if (choice == "2")
    {
        Console.WriteLine("\nYou have selected: Cappuccino");
    }
    else if (choice == "3")
    {
        Console.WriteLine("\nYou have selected: Espresso");
    }
    else if (choice == "4")
    {
        Console.WriteLine("\nYou have selected: Double espresso");
    }
    else 
    {
        Console.WriteLine("Incorrect value, please try again");
    }
