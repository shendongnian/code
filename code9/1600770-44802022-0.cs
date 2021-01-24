    int A;
    string B;
    string userinput = Console.ReadLine();
    // if parsing to int fails, asign to B
    if (!int.TryParse(userinput, out A)
    {
        B = userinput;
    }
