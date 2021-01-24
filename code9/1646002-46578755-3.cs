    static void Main()
    {
        var t = MethodA();
        MethodB1().ContinueWith((r) =>
        MethodB2()).Wait();
    }
    
    private static async Task MethodA()
    {
        await Task.Run(() =>
        {
            for (int i = 0; i < 40; i++)
            {
                Thread.Sleep(100);
                Console.WriteLine("A");
            }
        });
    }
    
    private static async Task MethodB1()
    {
        await Task.Run(() =>
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(100);
                Console.WriteLine("B1");
            }
        });
    }
    
    private static void MethodB2()
    {
        for (int i = 0; i < 10; i++)
        {
            Thread.Sleep(100);
            Console.WriteLine("B2");
        }
    }
