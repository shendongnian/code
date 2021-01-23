    bool valid = false;
    int workingAge;
    while (!valid)
    {
        valid = int32.TryParse(Console.ReadLine(), out workingAge);
        if (!valid)
            Console.WriteLine("Supplied number was invalid");
    }
    // Rest of code
