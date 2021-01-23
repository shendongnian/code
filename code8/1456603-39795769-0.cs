      var dates = new[]
      {
        new DateTime(2012, 1, 1),
        new DateTime(2012, 1, 2),
        new DateTime(2012, 12, 31),
        new DateTime(2013, 1, 1),
        new DateTime(2013, 1, 6),
        new DateTime(2013, 1, 7),
        new DateTime(2013, 12, 31),
        new DateTime(2014, 1, 1),
        new DateTime(2014, 1, 5),
        new DateTime(2014, 1, 6),
      };
      var calendar = CultureInfo.CurrentCulture.Calendar;
      foreach (var date in dates)
      {
        var day = calendar.GetDayOfYear(date);
        var week = calendar.GetWeekOfYear(date, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
        week = week > 52 ? 52 : week;
        Console.WriteLine($"{date.Date}: {day}: {week}");
      }
