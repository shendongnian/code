    public static void Main() {
        Console.Write("Farenheit Here>> ");
        Decimal F = Decimal.Parse(Console.ReadLine());
        Decimal FtoC = (5.0M / 9.0M) * (F - 32M);
        Console.WriteLine("The celsius is {0} ", FtoC);
    }
