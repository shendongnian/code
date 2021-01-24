    static class DateTimeExtensions
    {
        static GregorianCalendar _gc = new GregorianCalendar();
        public static string[] myCustomDateChains(this DateTime date)
        {
    
            string dayName = date.ToString("dddd");
            int weekOfMonth = GetWeekOfMonth(date);
    
            string[] array = new string[6];
    
            for (int i = 1; i < 7; i++)
            {
    
                DateTime dt = date.AddMonths(i);
                DateTime dtFirstDayOfMonth =  dt.AddDays(-(dt.Day - 1));
    
                for (int j = 0; j < 7; j++)
                {
    
                    if (dtFirstDayOfMonth.AddDays(j).ToString("dddd") == dayName)
                    {
                        array[i - 1] = dtFirstDayOfMonth.AddDays(j).ToString();
                        break;
                    }
    
                }
    
                //5th week of choosen month
                if (array[i - 1] == "")
                {
                    array[i - 1] = "doesnt found";
                }
    
            }
    
            
            return array;
        }
    
        static int GetWeekOfYear(this DateTime time)
        {
            return _gc.GetWeekOfYear(time, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
        }
    
        public static int GetWeekOfMonth(this DateTime time)
        {
            DateTime first = new DateTime(time.Year, time.Month, 1);
            return time.GetWeekOfYear() - first.GetWeekOfYear() + 1;
        }
    
    }
