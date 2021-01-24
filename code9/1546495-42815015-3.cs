    public static object GetDaysOfWeekXelementContent(DaysOfWeek pf)
    {
        var pfStr = pf.ToString();
        if (pfStr.Contains(","))
        {
            var pfStrValues = pfStr.Split(',').Select(x => (DaysOfWeek)Enum.Parse(typeof(DaysOfWeek), x.Trim())).OrderByDescending(x => (UInt64)x);
            return pfStrValues.Select(x => new XElement(x.ToString()));
        }
        else
        {
            return new XElement(pfStr);
        }
    }
