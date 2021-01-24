    DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
    var cal = dfi.Calendar;
    var shiftWeeks = from se in ShiftsOfEmployee
                     group se by cal.GetWeekOfYear(se.Day, dfi.CalendarWeekRule, dfi.FirstDayOfWeek)
                       into g
                     select new
                     {
                         WeekNumber = g.Key,
                         Units = g.Sum(s => Units(s.Start, s.End))
                     };
     var max = shiftWeeks.Max(wk => wk.Units);
     public static int Units(TimeSpan start, TimeSpan end) { ... }
