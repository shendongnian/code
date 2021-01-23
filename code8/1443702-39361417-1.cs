    class CD_GetOrAddOrUpdate
    {
        // Demonstrates:
        //      ConcurrentDictionary<TKey, TValue>.AddOrUpdate()
        //      ConcurrentDictionary<TKey, TValue>.GetOrAdd()
        //      ConcurrentDictionary<TKey, TValue>[]
        static void Main()
        {
            // Construct a ConcurrentDictionary
            ConcurrentDictionary<int, int> cd = new ConcurrentDictionary<int, int>();
    
            // Bombard the ConcurrentDictionary with 10000 competing AddOrUpdates
            Parallel.For(0, 10000, i =>
            {
                // Initial call will set cd[1] = 1.  
                // Ensuing calls will set cd[1] = cd[1] + 1
                cd.AddOrUpdate(1, 1, (key, oldValue) => oldValue + 1);
            });
    
            Console.WriteLine("After 10000 AddOrUpdates, cd[1] = {0}, should be 10000", cd[1]);
    
            // Should return 100, as key 2 is not yet in the dictionary
            int value = cd.GetOrAdd(2, (key) => 100);
            Console.WriteLine("After initial GetOrAdd, cd[2] = {0} (should be 100)", value);
    
            // Should return 100, as key 2 is already set to that value
            value = cd.GetOrAdd(2, 10000);
            Console.WriteLine("After second GetOrAdd, cd[2] = {0} (should be 100)", value);
        }
    }
