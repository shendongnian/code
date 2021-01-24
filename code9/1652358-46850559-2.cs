    private static void Ex3()
    {
        Console.WriteLine("A");
        
        IEnumerable<int> myIEnumerable = GetEnumerable();
        
        Console.WriteLine("B");
        
        var ordered = myIEnumerable.OrderBy(x => x).ToArray();
        
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
