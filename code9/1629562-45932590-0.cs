    public static Boolean IsSleeping()
    {
        TimeSpan now = DateTime.Now.TimeOfDay;
        TimeSpan before = new TimeSpan(  7,  0, 0 );
        TimeSpan after  = new TimeSpan( 21, 30, 0 );
        return now < before || now > after;
    }
