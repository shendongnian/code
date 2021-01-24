    Console.Write("What would you like to do? ");
    s = Console.ReadLine();
    if (s == "1")
    {
        Console.Write("Please Enter the vehicle ID: \n");
        ID = Console.Read();
        FlushKeyboard();
        Console.Write("Please enter the vehicle make: \n");
        make = Console.ReadLine();
        Console.Write("Please enter the vehicle model: \n");
        model = Console.ReadLine();
    
        Console.Write("Please enter the vehicle year: \n");
        year = Console.Read();
        FlushKeyboard();
    
        Vehicle v;
        v = new Vehicle
        {
            Id = ID,
            Make = make,
            Model = model,
            Year = year
        };
        Create(v);
    }
