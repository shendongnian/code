    public static DateTime NewTime(this DateTime dateTime)
    {
        int hour = dateTime.Hour;
        int minute = dateTime.Minute;
        var day = dateTime.Day;
        if (minute > 0)
        {
            minute = dateTime.Minute + (15);
            if (minute >= 60)
            {
                hour = hour + 1;
                minute = 0;
            }
        }
        if (hour > 24) {
            day += 1;
        }
        return new DateTime(dateTime.Year, dateTime.Month,
             day, hour, minute, 0);
    }
