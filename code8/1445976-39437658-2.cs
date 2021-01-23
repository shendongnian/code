    private void CreateHolidayWorkList()
    {
    
        WorkItem w;
        wList = new List<WorkItem>();
    
        foreach (DateTime dt in testDates)
        {
            // if today is Holiday, skip
            if (!IsHolidayOrWeekend(dt))
            {
                // is TOMORROW a holiday or weekend??
                //  AndAlso is it not alreay in the list
                if (IsHolidayOrWeekend(dt.AddDays(1)) && 
                        wList.FirstOrDefault(f=> f.Date.Date==dt.Date)==null)
                {
                    // current To-Do date 
                    w = new WorkItem(dt);
                    // scan ahead up to 6 days to find consecutive
                    // holiday/weekend dates
                    for (int n = 1; n <= 6; n++)
                    {
                        if (IsHolidayOrWeekend(dt.AddDays(n)))
                            w.AddDay(dt.AddDays(n));
                        else
                            break;
                    }
                    // add todo list to list
                    wList.Add(w);
                }
            }
        }
    }
    private bool IsHolidayOrWeekend(DateTime dt)
    {
        if (dt.DayOfWeek == DayOfWeek.Saturday || dt.DayOfWeek == DayOfWeek.Sunday)
            return true;
    
        return (hList.FirstOrDefault(q => q.Date == dt) != null);
    }
