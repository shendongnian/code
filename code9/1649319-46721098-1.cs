     var random = new Random();
     var bigList = Enumerable.Range(1, 1000000).Select(n => n.ToString());
     var smallList = Enumerable.Range(1, 1000000)
           .OrderBy(i => random.Next())
           .Take(1000)
           .Select(i => (i*2).ToString());
    
     var stopwatch = new Stopwatch();
     stopwatch.Start();
    
     var list = smallList.Intersect(bigList).ToList();
    
     stopwatch.Stop();
    
     Console.WriteLine($"{list.Count()} in {stopwatch.ElapsedMilliseconds}ms");
