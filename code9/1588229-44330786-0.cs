            public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
            {
                System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
                return dtDateTime;
            }
    
            public static long DateTimeToUnixTimeStamp(DateTime value)
            {
                long epoch = (value.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
                return epoch;
            }
