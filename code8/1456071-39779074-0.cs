    public DateTime NextTestDate(DateTime testDate, bool passed)
    {
        if (passed)
        {
            var now = DateTime.Now;
            if (DateTime.Now.Month < 3)
                return new DateTime(now.Year, 3, 2);
            if (DateTime.Now.Month < 9)
                return new DateTime(now.Year, 9, 2);
            return new DateTime(now.Year + 1, 3, 2); 
        }
        return testDate.AddDays(90);
    }
