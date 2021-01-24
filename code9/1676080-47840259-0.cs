    List<DateTime> dates = new List<DateTime>()
    {
        DateTime.Parse("2017-04-13 08:31:00.000"),
        DateTime.Parse("2017-04-12 07:53:00.000"),
        DateTime.Parse("2017-04-11 07:59:00.000"),
        DateTime.Parse("2017-04-10 08:16:00.000"),
        DateTime.Parse("2017-04-09 15:11:00.000")
    };
    Int64 avgTicks = (Int64)dates.Select(d => d.Ticks).Average();
    DateTime avgDate = new DateTime(avgTicks);
