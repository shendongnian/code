    public static void Main()
    {
        int loadingLength = 5;
        Console.Write("Loading...");
    
        for (int i = 0; i < loadingLength; i++)
            Console.Write(".");
            Thread.Sleep(500);
        }
    }
