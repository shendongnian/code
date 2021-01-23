    DateTime Now = DateTime.Now;
    if (Now.Hour < 16)
    {
        long TimeTo4 = (new TimeSpan(40, 0, 0).Ticks - Now.TimeOfDay.Ticks);
        TimeToInstall = TimeSpan.FromTicks(TimeTo4);
    }
    else
    {
        long TimeTo4 = (new TimeSpan(40, 0, 0).Ticks - Now.TimeOfDay.Ticks) + TimeGiven.Ticks;
        TimeToInstall = TimeSpan.FromTicks(TimeTo4);
    }
