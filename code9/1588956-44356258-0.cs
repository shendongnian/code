    bool success = false;
    double x1;
    while (!success)
    {
        Console.WriteLine("Type a number please: ");
        success = Double.TryParse(Console.ReadLine(), out x1);
    }
