    double dx;
    do
    {
        Console.Write("x = ");
        string x = Console.ReadLine();
        dx = Convert.ToDouble(x);
        Console.Write("X must be bigger than 1.");
    }
    while (dx > 1);
