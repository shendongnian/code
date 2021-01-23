    public static void PrintTo(int number)
    {
        if (number == 0)
            return;
        Console.WriteLine(number);
        PrintTo(number - 1);
    }
    static void Main(string[] args)
    {
        PrintTo(1000);
    }
