    string input = Console.ReadLine();
    if (Int32.TryParse(input, out _))
    {
        // input is int
    }
    else if (Single.TryParse(input, out _))
    {
        // input is float
    }
    else
    {
        // input is neither int nor float
    }
