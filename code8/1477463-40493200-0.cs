    Stopwatch watch = new Stopwatch();
    
    List<string> stringList = new List<string>();
    
    for (int i = 0; i < 10000000; i++)
    {
    	stringList.Add(i.ToString());
    }
    int t = 0;
    watch.Start();
    for (int i = 0; i < 1000000; i++)
    	if (stringList.Any(x => x == "29"))
    		t = i;
    		
    watch.Stop();
    ("Any takes: " + watch.ElapsedMilliseconds).Dump();
    GC.Collect();
    watch.Restart();
    
    for (int i = 0; i < 1000000; i++)
    	if (stringList.Contains("29"))
    		t = i;
    		
    watch.Stop();
    
    ("Contains takes: " + watch.ElapsedMilliseconds).Dump();
