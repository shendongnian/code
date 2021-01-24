    string uservalue = Console.ReadLine();
    int x;
    if(!int.TryParse(uservalue,out x))
    {
        Console.WriteLine("Invalid Input ! ");
        Console.ReadLine();
        return;
    }
    if (x >= 50 && x < 60)
    {
        Console.WriteLine("You Passed");
    }
    else if (x >= 60)
    {
        Console.WriteLine("Passed Grade B");
    }
