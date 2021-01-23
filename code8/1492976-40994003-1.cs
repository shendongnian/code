    int inFlight = 0;
    Parallel.For(0, doc.GetElementsByTagName("ItemID").Count, i => {
      System.Threading.Interlocked.Increment(ref inFlight);
      if (inFlight % 2 == 0)
       System.Threading.Thread.Sleep(TimeSpan.FromMinutes(2));
      var xmlResponse = PerformHttpRequestMethod();
      System.Threading.Interlocked.Decrement(ref inFlight);
    });
