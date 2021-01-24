    public static DateTime GetStartOfLastMonth(DateTime dt)
            {
                var date = dt.AddMonths(-1);
                return new DateTime(date.Year, date.Month, 1, 0, 0, 0, DateTimeKind.Local);
            }
    
            public static DateTime GetEndOfLastMonth(DateTime dt)
            {
                var date = dt.AddMonths(-1);
                var daysInLastMonth = DateTime.DaysInMonth(date.Year, date.Month);
    
                return new DateTime(date.Year, date.Month, daysInLastMonth, 0, 0, 0, DateTimeKind.Local);
            }
