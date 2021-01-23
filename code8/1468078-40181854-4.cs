    IEnumerable<int> randomQuery = Enumerable.Range(0, count).Select(i => r.Next(numitems));
    Stopwatch elapsed = new Stopwatch(); // only ONE instance needed
    for (int index = 0; index < iterations; index++)
    {
         arrayOfInts = randomQuery.ToArray();
         elapsed.Start();
         selectionSort(arrayOfInts);
         elpased.Stop();
    }
    TimeSpan averageTimeSpan = new TimeSpan(elapsed.ElapsedTicks/iterations);
