    public static DateTime GetCurrentTime()
        {
            TimeZoneInfo timeZone;
            DateTime time;
            try
            {
                timeZone = TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time");
                time = TimeZoneInfo.ConvertTime(DateTime.UtcNow, timeZone);
            }
            catch (Exception)
            {
                try
                {
                    timeZone = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");
                    time = TimeZoneInfo.ConvertTime(DateTime.UtcNow, timeZone);
                }
                catch (Exception)
                {
                    //logg not succeed
                    time = DateTime.Now;
                }
                
            }
            return time;
        }
