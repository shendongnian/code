    static void Main(string[] args)
    {
        for (int i = 0; i < 1000 * 1000; i++)
        {
            var j = i;
            Task.Run(() => WriteHelloAsync(j));
        }
    
        Console.ReadLine();
    }
