    static void Main(string[] args)
    {
        int var1 = 99;
        int var2 = 99;
        int var3 = 99;
        bool condition = false;
        string res = string.Format("{0}" + (condition ? "{1}" : string.Empty), var1, var2);
        Console.WriteLine(res);
        Console.ReadLine();
    }
