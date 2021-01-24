    var shiftWeeks = from se in ShiftsOfEmployee
                     group se by cal.GetWeekOfYear(se.Day, dfi.CalendarWeekRule, dfi.FirstDayOfWeek)
                       into g
                     select new
                     {
                         WeekNumber = g.Key,
                         Max = g.Max(s => Units(s.Start, s.End))
                     };
                     
