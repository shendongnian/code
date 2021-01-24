    static void Main(string[] args)
    {
        double test = 3.00;
        Console.WriteLine("number: " + test);
        Console.WriteLine("new number: " + string.Format("{0:0.00}", test));
        Console.ReadLine();
    }
