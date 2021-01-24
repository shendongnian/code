        for(var dt = start; dt<=end;dt=dt.AddDays(1))
        {
            if(dt.DayOfWeek!= DayOfWeek.Friday)
            {
                dates.Add(dt);
            }
            else
            {
                dt.AddDays(1);
            }
        }
