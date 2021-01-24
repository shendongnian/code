    private void SetUpTimer(TimeSpan alertTime, string name) 
    {
    
      DateTime current = DateTime.Now;
      TimeSpan timeToGo = alertTime - current.TimeOfDay;
      try
      {
        Timer timer = new Timer(x => RunReportTask(name),null, timeToGo, Timeout.InfiniteTimeSpan));
      }
      catch(Exception e)
      { 
        Console.WriteLine("Log Exception....")
      }
    }
