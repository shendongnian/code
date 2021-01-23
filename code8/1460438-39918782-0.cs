    var items = (new[] { "1", "2", "3","4","5","6","7","8","9","10" }).SelectMany(x => Enumerable.Repeat(x, 10000)).ToList();
    var itemsToFilterOut = new List<string> { "1", "2", "3" };
    
    var efficientItemsToFilterOut = new HashSet<string>(itemsToFilterOut);
    var watch = System.Diagnostics.Stopwatch.StartNew();
    var unwantedItems = items.Where(item => itemsToFilterOut.Contains(item)).ToList();
    watch.Stop();
    Console.WriteLine(watch.ElapsedMilliseconds);
    watch = Stopwatch.StartNew();
    var efficientUnwantedItems = items.Where(item => efficientItemsToFilterOut.Contains(item)).ToList();
    watch.Stop();
    Console.WriteLine(watch.ElapsedMilliseconds);
