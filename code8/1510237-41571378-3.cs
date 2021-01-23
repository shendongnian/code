    public static DateTime ToClientTime(this DateTime dt)
        {
            // read the value from session
            var timeOffSet = HttpContext.Current.Request["timezoneoffset"];
    
            if (timeOffSet != null)
            {
                var offset = int.Parse(timeOffSet.ToString());
                dt = dt.AddMinutes(-1 * offset);
    
                return dt;
            }
    
            // if there is no offset in session return the datetime as it is
            return dt;
        }
    public static DateTime ToUtcTime(this DateTime dt)
        {
            // read the value from session
            var timeOffSet = HttpContext.Current.Request["timezoneoffset"];
    
            if (timeOffSet != null)
            {
                var offset = int.Parse(timeOffSet.ToString());
                dt = dt.AddMinutes(offset);
    
                return dt;
            }
    
            // if there is no offset in session return the datetime as it is
            return dt;
        }
