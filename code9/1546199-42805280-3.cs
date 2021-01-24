    var schedules = new List<TimeSegment> { new TimeSegment(new DateTime(2017, 03, 14, 08, 00, 00), new DateTime(2017, 03, 14, 16, 00, 00)) };
    var bookings = new List<TimeSegment> 
    {
        new TimeSegment(new DateTime(2017, 03, 14, 09, 00, 00), new DateTime(2017, 03, 14, 10, 00, 00)),
        new TimeSegment(new DateTime(2017, 03, 14, 12, 00, 00), new DateTime(2017, 03, 14, 14, 00, 00)),
        new TimeSegment(new DateTime(2017, 03, 14, 13, 00, 00), new DateTime(2017, 03, 14, 15, 00, 00)),
    };
    foreach (TimeSegment booking in bookings)
    {
        var schedulesNew = new List<TimeSegment>();
        foreach (TimeSegment schedule in schedules)
        {
            var diff = schedule.Subtract(booking);
            schedulesNew.AddRange(diff);
        }
        schedules = schedulesNew;
    }
