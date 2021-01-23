    private static int[] numbers;
    static void Main(string[] args)
    {
        numbers = new int[7] {1, 2, 3, 4, 5, 6, 7};
        Timer t = new Timer(TimerOutput, 8, 0, 2000);
        Thread.Sleep(10000);
        t.Dispose();
        Console.ReadLine();
    }
    private static void TimerOutput(Object state)
    {
        // numbers is available in this method.
        Console.WriteLine(""); 
        Thread.Sleep(1000);
    }
