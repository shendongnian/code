    DateTime currentDate = DateTime.Now;
    DateTime downInterval = DateTime.Now.AddDays(-1);
    DateTime upInterval = DateTime.Now.AddDays(1);
    if (currentDate.Ticks > downInterval.Ticks && currentDate.Ticks < upInterval.Ticks)
    {
  
    }
