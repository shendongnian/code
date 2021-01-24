    public static void Demo()
    {
        var rnd = new Random();
        var counter = 0;
        for (var i = 0; i < 10; ++i)
        {
            Console.SetCursorPosition(1, 1);
            Console.WriteLine($"Current counter value {counter}");
            Thread.Sleep(400);
            counter += rnd.Next(42);
        }
    }
