    List<long> ticks = new List<long>();
    IEnumerable<int> randomQuery = Enumerable.Range(0, count).Select(i => r.Next(numitems));
    for (int index = 0; index < iterations; index++)
    {
         //creates NEW random numbers each time, because of deferred execution
         arrayOfInts = randomQuery.ToArray(); 
         ...
