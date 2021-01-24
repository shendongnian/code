    bool continue = true;
    while (continue)
    {
        Console.WriteLine("Enter Customer Details (s)"); 
        Console.WriteLine("Enter usage data (u)"); 
        Console.WriteLine("Display usage data (d)");
        Console.WriteLine("Exit (e)");
        string menu = Console.ReadLine();
        switch (menu)
        {
            case "s":
                //statement 
                break;
            case "u":
                //statement 
                break; 
            case "d":
                //statement 
                break; 
            case "e":
            default: 
                continue = false;
                break;
        }
    }
