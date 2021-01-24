      int inc = 15;
      DateTime startTime = DateTime.Now;
      DateTime endTime = DateTime.Now.AddDays(1).Date.AddTicks(-1);
      List<DateTime> timeList = new List<DateTime>();
      Console.WriteLine("startTime:: " + startTime);
      Console.WriteLine("endTime:: " + endTime);
      while (startTime < endTime)
      {
        timeList.Add(startTime);
        Console.WriteLine(startTime.TimeOfDay);
        startTime = startTime.AddMinutes(inc);
      }
