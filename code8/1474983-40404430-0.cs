    public struct DateTimeZone
    {
        public DateTime DateTime;
        public static explicit operator DateTimeZone(DateTime dt)
        {
            return new DateTimeZone { DateTime = dt.ToUniversalTime() };
        }
    }
    var time = (DateTimeZone)DateTime.Now;
    var localTime = time.DateTime; 
