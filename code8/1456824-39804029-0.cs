    static void Main(string[] args)
    {
        int i;
        int[] n = new int[11];
        Console.WriteLine("please enter 10 numbers");
        for (i = 1; i <= 10; i++)
            n[i] = Convert.ToInt32((Console.ReadLine()));
        for (i = 10; i >= 1; i--)
        Console.WriteLine(n[i] + " ");
        Console.ReadKey();
    }
