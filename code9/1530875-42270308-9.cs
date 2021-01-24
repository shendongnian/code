    public static class Extensions
    {
        public static DateTime AddMonths(this DateTime date, decimal months)
        {
            var start = date;
            decimal daysInStartMonth = DateTime.DaysInMonth(start.Year, start.Month);
            var daysApartInStartMonth = (daysInStartMonth - start.Day + 1) / daysInStartMonth;
            if (months <= daysApartInStartMonth)
            {
                return date.AddDays((double)(months * daysInStartMonth - 1));
            }
            var finish = date.AddMonths(1);
            int monthsApart = 0;
            if (months > daysApartInStartMonth + 1)
            {
                monthsApart = (int)(months - daysApartInStartMonth);
                finish = finish.AddMonths(monthsApart);
            }
            decimal daysInFinishMonth = DateTime.DaysInMonth(finish.Year, finish.Month);
            var startOfFinishMonth = new DateTime(finish.Year, finish.Month, 1).AddDays(-1);
            decimal remaining = months - daysApartInStartMonth - monthsApart;
            return startOfFinishMonth.AddDays((double)(remaining * daysInFinishMonth));
        }
    }
