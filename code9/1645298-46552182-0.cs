    public static DateTime GetRoundedDate(DateTime originalDate)
    {
        if(originalDate.Hour > 19)
            return originalDate.Date.AddDays(1).AddHours(6);
        else if (originalDate.Hour < 6)
            return originalDate.Date.AddHours(6);
        return originalDate;
    }
