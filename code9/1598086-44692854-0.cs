    while (calculateAgain == "y")
    {
        // ...
        if (IpValidation(ip) == false)
        {
            Console.WriteLine("Ugyldig IP og eller Subnet mask!\n");
            continue;
        }
        Console.WriteLine("This will not be executed when continue is called");
    }
