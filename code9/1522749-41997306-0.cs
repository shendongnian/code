    static void Main()
    {
        for (int i = 0; ;)
        {
            Console.Write(i++);
            Thread.Sleep(250);
            if (Console.WindowHeight>0 && Console.WindowWidth>0)
                Console.Clear();
        }
    }
