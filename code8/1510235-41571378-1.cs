    public static string ToClientTime(this DateTime dt)
        {
            // read the value from session
            var timeOffSet = HttpContext.Current.Request["timezoneoffset"];
    
            if (timeOffSet != null)
            {
                var offset = int.Parse(timeOffSet.ToString());
                dt = dt.AddMinutes(-1 * offset);
    
                return dt.ToString();
            }
    
            // if there is no offset in session return the datetime in server timezone
            return dt.ToLocalTime().ToString();
        }
    public static string ToUtcTime(this DateTime dt)
        {
            // read the value from session
            var timeOffSet = HttpContext.Current.Request["timezoneoffset"];
    
            if (timeOffSet != null)
            {
                var offset = int.Parse(timeOffSet.ToString());
                dt = dt.AddMinutes(offset);
    
                return dt.ToString();
            }
    
            // if there is no offset in session return the datetime in server timezone
            return dt.ToLocalTime().ToString();
        }
