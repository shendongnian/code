    public static TimeSpan AddTimeSpan(this TimeSpan ts1, TimeSpan ts2)
    {
        bool sign1 = ts1 < TimeSpan.Zero, sign2 = ts2 < TimeSpan.Zero;
        if (sign1 && sign2)
        {
            if (TimeSpan.MinValue - ts1 > ts2)
            {
                return TimeSpan.MinValue;
            }
        }
        else if (!sign1 && !sign2)
        {
            if (TimeSpan.MaxValue - ts1 < ts2)
            {
                return TimeSpan.MaxValue;
            }
        }
 
        return ts1 + ts2;
    }
