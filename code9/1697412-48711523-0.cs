    var r = new Random();
    var t = new System.Timers.Timer() { Interval = 1500 };
    t.Elapsed += (s, e) =>
    	Console.WriteLine(DateTime.Now.TimeOfDay);
    t.Start();
    while (true)
    {
    	Thread.Sleep(r.Next(500, 1000));
    	Console.WriteLine("doing stuff");
    }
---
     
    var r = new Random();
    var prev = DateTime.Now;
    var interval = 1500;
    while (true)
    {
    	Thread.Sleep(r.Next(500, 1000));
    	Console.WriteLine("doing stuff");
        var now = DateTime.Now;
    	if (prev.AddMilliseconds(interval) >= now)
    	{
    	    prev = DateTime.Now;
    	    Console.WriteLine(DateTime.Now.TimeOfDay);
    	}
    }
