    private static void Ex2()
    {
        Console.WriteLine("A");
        
        IEnumerable<int> myIEnumerable = GetEnumerable();
        
        Console.WriteLine("B");
        
        var ordered = myIEnumerable.OrderBy(x => x);
        
        foreach (int i in ordered)
        {
            Console.WriteLine("*** foreach : " + i);
            if (i == ordered.First())
            {
                Console.WriteLine("=== Matched .First() : " + i);
            }
        }
    
        Console.WriteLine("C");
    }
