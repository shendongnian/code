    public DateTime GetNextTestDate(DateTime testDate, bool passed)
    {
	    if (passed)
        {
            if (testDate.Month >= 3 && testDate.Month < 9)
                return new DateTime(testDate.Year, 9, 30);
            else
                return new DateTime(testDate.Year + (testDate.Month >= 9 && testDate.Month <= 12 ? 1 : 0), 3, 31);  // (add a year if we're 9-12)
        }
        else
            return testDate.AddDays(90);
    }
