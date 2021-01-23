    public DateTime BuildDate(Int32 day, Int32 hour, Int32 minute)
            {
                var now = DateTime.Now;
    
                var initialDate = now.AddDays(((Int32)now.DayOfWeek + 1) * -1);
    
                return new DateTime(initialDate.Year, initialDate.Month, initialDate.AddDays(day).Day, hour, minute, 0);
            }
