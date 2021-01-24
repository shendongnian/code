    var tests = new [] {
      new DateTime(2017,12,22,6,44,59),
      new DateTime(2017,12,22,6,45,0),
      new DateTime(2017,12,22,6,45,1),
      new DateTime(2017,12,22,7,5,0),
      new DateTime(2017,12,22,7,5,1), 
      new DateTime(2017,12,22,12,20,0),
      new DateTime(2017,12,22,12,35,1),
    };
    
    foreach(var test in tests)
    {
      BetweenTime.GetCorrectedTime(test).Dump(test.ToString());
    }
