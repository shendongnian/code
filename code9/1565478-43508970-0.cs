    public int verifyHour()
    {
        Datetime nowConverted = Convert.ToDateTime(DateTime.Now.ToString("HH:mm:ss"));
        if (IsTimeOfDayBetween(nowConverted, new TimeSpan(20, 25, 0), new TimeSpan(20, 30, 0)))
        {
            return 1;
        }
        for(int i = 2, time = 8; i <= 12; ++i, ++time)
        {
            if (IsTimeOfDayBetween(nowConverted, new TimeSpan(time, 00, 0), new TimeSpan(time + 1, 00, 0))
            {
                return i;
            }
            else if (time == 9) //You don't compare between 10 and 11
            {
                ++time;
            }
            else if (time == 16) //You repeat this twice, so 10 will never be returned
            {
                ++i;
            }
        }
        return -1;
    }
