    private static void MethodA()
    {
        for (int i = 0; i < 100; i++)
        {
            Console.Write("A ");
            Thread.Sleep(100);
        }  
    }
    private static void MethodB1()
    {
       
        for (int i = 0; i < 100; i++)
        {
            Console.Write("B1 ");
            Thread.Sleep(100);
        }
    }
    private static void MethodB2()
    {
        for (int i = 0; i < 100; i++)
        {
            Console.Write("B2 ");
            Thread.Sleep(100);
        }
    }
