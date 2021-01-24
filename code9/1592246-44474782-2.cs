    double input;
    bool success = double.TryParse(Console.ReadLine(), out input);
    if(success)
    {
        y.Player(input);
    }
