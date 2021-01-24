    public DateTime FindNextDate(int dayOfMonth, DateTime today)
    {
      DateTime yesterday = today.AddDays(-1);
      DateTime currentMonthStart = new DateTime(today.Year, today.Month, 1);
      var query = Enumerable.Range(0, 100)
        .Select(i => currentMonthStart.AddMonths(i))
        .Select(monthStart => MakeDateOrDefault(
          monthStart.Year, monthStart.Month, dayOfMonth,
          yesterday)
        .Where(date => today <= date)
        .Take(1);
    
      List<DateTime> results = query.ToList();
      if (!results.Any())
      {
        throw new ArgumentOutOfRangeException(nameof(dayOfMonth))
      }
      return results.Single();
    }
    public DateTime MakeDateOrDefault(
      int year, int month, int dayOfMonth,
      DateTime defaultDate)
    {
      try
      {
        return new DateTime(year, month, dayOfMonth);
      }
      catch
      {
        return defaultDate;
      }
    }
