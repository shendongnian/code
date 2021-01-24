    var results = new int[5];
    var intList = new List<int>();            
	for(var i = 0; i < 2500000; i++)
	{
		intList.Add(i);   
	}
    watch.Restart();
	Parallel.ForEach(intList, i =>
	{
        Interlocked.Increment(ref results[i % 5]);
	});
	timers.Add(watch.ElapsedMilliseconds / 1000.0);  // ~1.3 seconds
