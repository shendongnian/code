    public static object GetDaysOfWeekXelementContent(DaysOfWeek pf)
    {
        var pfStr = pf.ToString();
        var pfStrSplit = pfStr.Split(',');
        if(pfStrSplit.Length > 1)
        {
            var allXElements = pfStrSplit.Select(x => new XElement(x.Trim()));
            return allXElements.ToList();
        }
        else
        {
            return new XElement(pfStr);
        }
    }
    
    static void Main(string[] args)
    {
        List<DaysOfWeek> profiles = new List<DaysOfWeek>();
        profiles.Add(DaysOfWeek.MondayToFriday);
        profiles.Add(DaysOfWeek.MondayToSaturday);
        profiles.Add(DaysOfWeek.Monday | DaysOfWeek.Tuesday);
    
        XElement xml = new XElement("Profiles",
                            from DaysOfWeek pf in profiles
                            select new XElement("Profile", GetDaysOfWeekXelementContent(pf))
                        );
        Console.WriteLine(xml);
    }
