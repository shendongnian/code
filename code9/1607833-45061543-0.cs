    public static void runCode(int num)
    {
        Console.WriteLine("Task {0}", num);
        for (int j = 0; j < 10; j++)
            Console.Write(num);
    }
    public static void Main(string[] args)
    {
        // some operations here
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Current number={0}", i);
            var x = i;
            Task.Run(() => runCode(x));
        }
        // remaining code
    }
