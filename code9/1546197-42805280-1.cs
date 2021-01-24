    var schedules = new List<TimeSegment> { new TimeSegment(new DateTime(2017, 03, 14, 08, 00, 00), new DateTime(2017, 03, 14, 16, 00, 00)) };
    var bookings = new List<TimeSegment> 
    {
        new TimeSegment(new DateTime(2017, 03, 14, 09, 00, 00), new DateTime(2017, 03, 14, 10, 00, 00)),
        new TimeSegment(new DateTime(2017, 03, 14, 12, 00, 00), new DateTime(2017, 03, 14, 14, 00, 00)),
        new TimeSegment(new DateTime(2017, 03, 14, 13, 00, 00), new DateTime(2017, 03, 14, 15, 00, 00)),
    };
    foreach (var booking in bookings)
    {
        var schedulesNew = new List<TimeSegment>();
        foreach (var ts in schedules)
        {
            schedulesNew.AddRange(ts.Subtract(booking));
        }
        schedules = schedulesNew;
    }
