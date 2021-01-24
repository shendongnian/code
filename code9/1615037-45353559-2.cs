    DateTime start = new DateTime(2017, 07, 11, 0, 0, 0, 0, 0);
    DateTime end = start.AddDays(1);
    var results = tmOpen1.Calendar.
                        .Where( c => ! ( c.Start >= end  ||  c.End <= start) )
                        .Select(x => new { ID = x.PersonID } );
