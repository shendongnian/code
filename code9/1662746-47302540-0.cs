    protected IEnumerable<double> getWorkingHrsPerDay(DateTime _dtTaskStart, DateTime _dtTaskEnd)
    {
        double count = 0;
        DateTime lastHandledDate = _dtTaskStart.Date;
        for (var i = _dtTaskStart; i < _dtTaskEnd; i = i.AddHours(1))
        {
            if (i.DayOfWeek != DayOfWeek.Saturday && i.DayOfWeek != DayOfWeek.Sunday)
            {
                if (i.TimeOfDay.Hours >= 9 && i.TimeOfDay.Hours < 17)
                {
                    count++;
                }
            }
            //if we have started to count the hours for a new day
            if (lastHandledDate.Date != i.Date)
            {
                lastHandledDate = i.Date;
                double hourCount = count;
                //reset our hour count
                count = 0;
                //we return the count of the last day
                yield return hourCount;
            }
            lastHandledDate = i.Date;
        }
    }
