    static void A(int currentValue)
    {
        lock (_object)
        {
            Console.WriteLine(currentValue + " Start");                
            Console.WriteLine(currentValue + " End");
        }
    }
