    public IEnumerable<DateTime> GetMonths(DateTime startDate, DateTime endDate)
    {
        if(startDate > endDate) 
        {
            throw new ArgumentException(
                $"{nameof(startDate)} cannot be after {nameof(endDate)}");
        }
        startDate = new DateTime(startDate.Year, startDate.Month, 1);
        while (startDate <= endDate)
        {
            yield return startDate;
            startDate = startDate.AddMonths(1);
        }
    }
