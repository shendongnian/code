    Console.Write("Input money : ");
    float money = Console.Read();          
    double tax = 0;
    if (money < 10000)
    {
        tax = .05 * money;
    }
    else if (money <= 100000)
    {
        tax = .08 * money;
    }
    else
    {
        tax = .085 * money;
    }
    
    Console.WriteLine("Tax is {0}", tax);
    Console.ReadLine();
