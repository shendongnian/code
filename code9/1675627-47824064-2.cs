    double decoration;
    if (!double.TryParse(Console.ReadKey().KeyChar.ToString(), out decoration))
    {
        Console.WriteLine("The value you entered is not a valid double.");
    }
