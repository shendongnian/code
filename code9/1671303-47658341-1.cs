    Console.ForegroundColor = ConsoleColor.Green;
    string[] Class = new string[] { "AA", "BB", "CC", "DD", "EE", "FF", "GG", "HH", "II", "JJ", "KK", "LL", "MM", "NN", "OO" };
    double[] Rate = new double[] { .015, .023, .010, .042, .051, .004, .022, .030, .001, .010, .020, .030, .045, .033, .050 };
    Console.Write("Please enter vehicle classification: ");
    string Vclass = Console.ReadLine();
    if (!Class.Contains(Vclass))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("There is an error with the vehicle class.");
        Console.ForegroundColor = ConsoleColor.Green;
    }
