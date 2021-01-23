    double length;
    Console.WriteLine("Enter length of one side: ");
    if (!double.TryParse(Console.ReadLine(), out length))
        Console.WriteLine("Invalid value, must be a number or decimal value.");
    Square sq = new Square();
    sq.Length = length;
    Console.WriteLine(sq.CalculateArea().ToString("F"));
