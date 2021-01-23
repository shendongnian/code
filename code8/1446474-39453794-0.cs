    static readonly int DayOffset = (new DateTime(DateTime.Today.Year, 5, 1) 
                                   - new DateTime(DateTime.Today.Year, 1, 1)).Days; // 121
    // ... somewhere else:
    DateTime date = DateTime.Today;
    DateTime offsetDate = date.AddDays(-DayOffset);
    int weekNum = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(offsetDate, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday); 
    Console.WriteLine("Year:{0} Week:{1}", offsetDate.Year, weekNum); // Year:2016 Week:19
