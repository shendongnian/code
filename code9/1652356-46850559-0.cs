    private static void Ex1()
    {
        Console.WriteLine("A");
        
        IEnumerable<int> myIEnumerable = GetEnumerable();
        
        Console.WriteLine("B");
        
        foreach (int i in myIEnumerable.OrderBy(x => x))
        {
            Console.WriteLine("*** foreach : " + i);
            if (i == myIEnumerable.First())
            {
                Console.WriteLine("=== Matched .First() : " + i);
            }
        }
    
        Console.WriteLine("C");
    }
