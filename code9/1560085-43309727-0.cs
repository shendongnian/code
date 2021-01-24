    public static void Main(string[] args)
    {            
      DateTime StartTime = DateTime.Now;
      /// do something here... that actually takes time
      Thread.Sleep(TimeSpan.FromSeconds(1));
      /// next estimate update
      {
        double WorkDone = 0.10; // e.g. 10%... give some indication how much work has been done between 0 and 1
        TimeSpan TimeSpent = DateTime.Now - StartTime;
        TimeSpan TimeOverall = TimeSpan.FromTicks((long) (TimeSpent.Ticks / WorkDone));
        TimeSpan TimeRemaining = TimeOverall - TimeSpent;
        Console.WriteLine(TimeRemaining.TotalSeconds);
      }
    }
