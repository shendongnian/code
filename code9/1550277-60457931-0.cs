    static IEnumerable<string> Iterator()
    {
        try
        {
            Console.WriteLine("Before first yield");
            yield return "first";
            Console.WriteLine("Between yields");
            yield return "second";
            Console.WriteLine("After second yield");
        }
        finally
        {
            Console.WriteLine("In finally block");
        }
    }
