    public static int weekends(DateTime start, DateTime end, List<DateTime> holidays)
        {
            int days = 0;
            DateTime tempEnd = end;
            TimeSpan startEnd = end - start;
            int currentDays = startEnd.Days;
            
                int exclusionDays = 0;
                int exclWEOld = 0;
                int exclHDOld = 0;
                while (currentDays >= 0)
                {
                    int excHolidayTest = exclHolidays(start, tempEnd, holidays);
                    int excDayTest = exclDays(start, tempEnd);
                    if (exclusionDays == (excDayTest+ excHolidayTest))
                    {
                        break;
                    }
                    else
                    {
                        exclusionDays = excDayTest + excHolidayTest;
                        if (exclWEOld == 0 && exclHDOld == 0)
                        {
                            tempEnd = tempEnd.AddDays((excDayTest + excHolidayTest));
                        }
                        else
                        {
                            tempEnd = tempEnd.AddDays((excDayTest - exclWEOld));
                            tempEnd = tempEnd.AddDays((excHolidayTest - exclHDOld));
                        }
                        exclWEOld = excDayTest;
                        exclHDOld = excHolidayTest;
                    }
                    days = excDayTest + excHolidayTest;
                    currentDays--;
                }
            
            return days;
        }
        public static int exclDays(DateTime start, DateTime end)
        {
            int exclusionDays = 0;
            for (DateTime date = start; date <= end; date = date.AddDays(1))
            {
                int dw = (int)date.DayOfWeek;
                if (dw == 0 || dw == 6)
                {
                    exclusionDays++;
                }
            }
            return exclusionDays;
        }
        public static int exclHolidays(DateTime start, DateTime end, List<DateTime> holidays)
        {
            int exclusionHolidays = 0;
            
            foreach (DateTime holiday in holidays.Where(r => r.Date >= start.Date && r.Date <= end.Date))
            {
                exclusionHolidays++;
            }
            return exclusionHolidays;
        }
