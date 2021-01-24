    public static object GetDaysOfWeekXelementContent(DaysOfWeek pf)
    {
        var pfStr = pf.ToString();
        if (pfStr.Contains(","))
        {
            return pfStr.Split(',').Reverse().Select(x => new XElement(x.Trim()));
        }
        else
        {
            return new XElement(pfStr);
        }
    }
