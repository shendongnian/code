    TimeSpan TimeToInstall;                
    TimeSpan TimeGiven = new TimeSpan(23, 59, 59);        
    DateTime Now = DateTime.Now;
    long TimeTo4 = (new TimeSpan(40, 0, 0).Ticks - Now.TimeOfDay.Ticks) + TimeGiven.Ticks;
    TimeToInstall = TimeSpan.FromTicks(TimeTo4);
