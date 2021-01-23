    public static int DayDiff(DateTime d1, DateTime d2)
    {
        DateTime min, max;
        if(d1 < d2)
        {
            min = d1; max = d2;
        }
        else
        {
            min = d2; max = d1;
        }
        int nbOfDays = 0;
        while(max.Date != min.Date)
        {
            min = min.AddDays(1);
            if (min.Month != 2 || min.Day != 29) // Skip leap day
                nbOfDays++;
        }
        return nbOfDays;
    }
