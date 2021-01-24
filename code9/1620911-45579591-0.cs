    Input : "Mon-Thu, Sun" 
    OutPut: Monday, Tuesday, Wednesday, Thursday, Sunday
    Input : "Mon, Wed-Thu, Sun" 
    OutPut: Monday, Wednesday, Thursday, Sunday
    List<DayOfWeek> ListOfDays()
    {
        var str = "Mon-Thu, Sun";
        string[] split = str.Split(',');
    
        var days = new List<DayOfWeek>();   
        foreach (var item in split)
        {
            if (item.IndexOf('-') < 0)
            {
                days.Add(GetDayOfWeek(item.Trim()));
                continue;
            }
    
            var consecutiveDays = item.Split('-');
            DayOfWeek startDay = GetDayOfWeek(consecutiveDays[0].Trim());
            DayOfWeek endDay = GetDayOfWeek(consecutiveDays[1].Trim());
    
            for (DayOfWeek day = startDay; day <= endDay; day++)
                days.Add(day);
        }
        
        return days;
    }
    
    DayOfWeek GetDayOfWeek(string day)
    {
        switch (day.ToUpper())
        {
            case "MON":
                return DayOfWeek.Monday;
                break;
            case "TUE":
                return DayOfWeek.Tuesday;
                break;
            case "WED":
                return DayOfWeek.Wednesday;
                break;
            case "THU":
                return DayOfWeek.Thursday;
                break;
            case "FRI":
                return DayOfWeek.Friday;
                break;
            case "SAT":
                return DayOfWeek.Saturday;
                break;
            case "SUN":
                return DayOfWeek.Sunday;
                break;
            default:
                throw new ArgumentException("Invalid day");
                break;
        }
    }
