    Console.Clear();
    string choice;
    Dictionary<string, string> choiceToCoffee = new Dictionary<string, string>()
    {
        { "1", "Latte" },
        { "2", "Cappuccino" },
        { "3", "Espresso" },
        { "4", "Double Espresso" },
    };
    Console.WriteLine("Welcome to Costa coffee\n");
    foreach (var kvp in choiceToCoffee)
    {
        var thisChoice = kvp.Key;
        var thisCoffee = kvp.Value;
        Console.WriteLine(thisChoice + ":> " + thisCoffee);
    }
    Console.WriteLine("\nPlease select a coffee by pressing 1-4");
    choice = Console.ReadLine();
    if (choiceToCoffee.ContainsKey(choice))
    {
        Console.WriteLine("\nYou have selected: " + choiceToCoffee[choice]);
    }
    else
    {
        Console.WriteLine("Incorrect value, please try again");
    }
