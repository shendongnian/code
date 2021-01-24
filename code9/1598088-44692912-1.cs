    while (calculateAgain == "y")
    {
        Console.Write("Your ip here: ");
        string ip = Console.ReadLine();
    
        IpValidation(ip);
        if (IpValidation(ip) == false)
        {
            Console.WriteLine("Ugyldig IP og eller Subnet mask!\n");
            continue;
        }
    }
