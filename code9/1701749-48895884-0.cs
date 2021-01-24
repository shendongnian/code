    timesheetEntries
        .GroupBy( te => te.EmployeeId )
        .Select(
            grp => new {
                EmployeeId = grp.Key,
                DayCount = grp
                    .Select( te => te.ClockInTimeStamp.Date )
                    .Distinct()
                    .Count()
            }
        )
        .ToDictionary(
            t => t.EmployeeId,
            t => t.DayCount
        );
