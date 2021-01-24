    static void Main(string[] args)
    {
        double var1 = 99.9;
        double var2 = 99.1;
        bool condition = false;
        string res = string.Format(CultureInfo.InvariantCulture, "{0}" + (condition ? "{1}" : string.Empty), var1, var2);
        Console.WriteLine(res);
        Console.ReadLine();
    }
