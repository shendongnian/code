    Dictionary<string, DayOfWeek> days = new Dictionary<string, DayOfWeek>
    {
        ["Mon"] = DayOfWeek.Monday,
        ["Tue"] = DayOfWeek.Tuesday,
        ["Wed"] = DayOfWeek.Wednesday,
        ["Thu"] = DayOfWeek.Thursday,
        ["Fri"] = DayOfWeek.Friday,
        ["Sat"] = DayOfWeek.Saturday,
        ["Sun"] = DayOfWeek.Sunday
    };
    
    //Get the next day in the week by calculating modulo 7
    DayOfWeek NextDay(DayOfWeek day) => (DayOfWeek)(((int)day + 1) % 7);
    
    List<DayOfWeek> GetDays(string input)
    {
        var ranges = input.Split(',');
        var daysList = new List<DayOfWeek>();
    
        foreach(var range in ranges)
        {
            var bounds = range.Split('-').Select(s => s.Trim()).ToList();
            if(bounds.Count == 1)
            {
                if(days.TryGetValue(bounds[0], out var day))
                    daysList.Add(day);
                else
                    throw new FormatException("Couldn't find day");
            }
            else if(bounds.Count == 2)
            {
                if(days.TryGetValue(bounds[0], out var begin) && days.TryGetValue(bounds[1], out var end))
                {
                    if(begin == NextDay(end)) // whole week in one range
                    {
                        daysList.AddRange(days.Values);
                        var returnSet = new SortedSet<DayOfWeek>(daysList); //remove duplicates and sort
                        return returnSet.ToList();
                    }
                    
                    for(var i = begin; i != NextDay(end); i = NextDay(i))
                    {
                        daysList.Add(i);
                    }
                }
                else
                    throw new FormatException("Couldn't find day");
            }
            else
                throw new FormatException("Too many hyphens in one range");
        }
    
        var set = new SortedSet<DayOfWeek>(daysList); //remove duplicates and sort
        return set.ToList();
    }
        
    var input = "Mon-Thu, Sun";
    foreach(var day in GetDays(input))
    {
        Console.WriteLine(day);
    }
