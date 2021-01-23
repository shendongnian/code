    DateTime dTime = DateTime.Parse(/*String from sql database*/);
    DayOfWeek weekdayFrom = DayOfWeek.Tuesday;
    DayOfWeek weekdayTo = DayOfWeek.Wednesday;
    double hourFrom = 12;
    double hourTo = 18;
    DateTime periodStart = dTime.AddDays(weekdayFrom - dTime.DayOfWeek).Date.AddHours(hourFrom);
    DateTime periodEnd = dTime.AddDays(weekdayTo - dTime.DayOfWeek).Date.AddHours(hourTo);
    
    if ((dTime >= periodStart) && (dTime <= periodEnd))
