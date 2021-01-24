    static void Main(string[] args)
    {
        var town = Console.ReadLine().ToLower();
        var amount = double.Parse(Console.ReadLine());
        double result = 0.0;
        if (town == "sofia")
        {
            if (amount >= 0 && amount <= 500)
            {
                result = amount * (0.05);
            }
            else if (amount >= 500 && amount <= 1000)
            {
                result = amount * (0.07);
            }
            else if (amount >= 1000 && amount <= 10000)
            {
                result = amount * (0.08);
            }
            else if (amount > 10000)
            {
                result = amount * (0.12);
            }
        }
        double f = result;
        Console.WriteLine("{0:f2}", result);
        Console.ReadKey();
    }
