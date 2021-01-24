    double decoration;
    while (!double.TryParse(Console.ReadLine(), out decoration))
    {
        Console.WriteLine("The value you entered is not a valid double.");
        Console.Write("Please Choose decoration 1 or 2: ");
    }
