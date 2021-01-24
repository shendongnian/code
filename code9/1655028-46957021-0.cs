    Console.WriteLine("How big is the number?");
    double amount = Convert.ToDouble(Console.Readline());
    
    if (amount < 500.0)
    {
        Console.WriteLine("smaller than 500");
    }
    else if (amount < 2000.0)
    {
        Console.WriteLine("bigger or same as 500 but smaller than 2000");
    }
    else if (amount < 5000.0)
    {
        Console.WriteLine("bigger or same as 2000 but smaller than 5000");
    }
    else
    {
        Console.WriteLine("bigger or same as 5000");
    }
    Console.ReadLine();
    Console.Read();
