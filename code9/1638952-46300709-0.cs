        long GetDateTimeMS(int yr, int month, int day, int hr, int min)
        {
            Java.Util.Calendar c = Java.Util.Calendar.GetInstance(Java.Util.TimeZone.Default);
            c.Set(Java.Util.Calendar.DayOfMonth,day);
            c.Set(Java.Util.Calendar.HourOfDay, hr);
            c.Set(Java.Util.Calendar.Minute, min);
            if (month == 1)
            {
                c.Set(Java.Util.Calendar.Month, Java.Util.Calendar.January);
            }
            else if (month == 2)
            {
                c.Set(Java.Util.Calendar.Month, Java.Util.Calendar.February);
            }
            else if (month == 3)
            {
                c.Set(Java.Util.Calendar.Month, Java.Util.Calendar.March);
            }
            else if (month == 4)
            {
                c.Set(Java.Util.Calendar.Month, Java.Util.Calendar.April);
            }
            else if (month == 5)
            {
                c.Set(Java.Util.Calendar.Month, Java.Util.Calendar.May);
            }
            else if (month == 6)
            {
                c.Set(Java.Util.Calendar.Month, Java.Util.Calendar.June);
            }
            else if (month == 7)
            {
                c.Set(Java.Util.Calendar.Month, Java.Util.Calendar.July);
            }
            else if (month == 8)
            {
                c.Set(Java.Util.Calendar.Month, Java.Util.Calendar.August);
            }
            else if (month == 9)
            {
                c.Set(Java.Util.Calendar.Month, Java.Util.Calendar.September);
            }
            else if (month == 10)
            {
                c.Set(Java.Util.Calendar.Month, Java.Util.Calendar.October);
            }
            else if (month == 11)
            {
                c.Set(Java.Util.Calendar.Month, Java.Util.Calendar.November);
            }
            else if (month == 12)
            {
                c.Set(Java.Util.Calendar.Month, Java.Util.Calendar.December);
            }
            c.Set(Java.Util.Calendar.Year,yr);
            return c.TimeInMillis;
        }
