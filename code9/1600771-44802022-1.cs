    int A;
    string B;
    string userinput = Console.ReadLine();
    // if parsing to int fails, assign to B
    if (!int.TryParse(userinput, out A)
    {
        B = userinput;
    }
