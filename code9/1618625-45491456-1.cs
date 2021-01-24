    // Simulate linq connection
    var db = new
    {
        Schedules = new List<Schedule>
        {
            new Schedule() { hours = 40, week_ending = new DateTime(2017,8,11) },
            new Schedule() { hours = 20, week_ending = new DateTime(2017,8,18) }, // Simulating multiple records
            new Schedule() { hours = 20, week_ending = new DateTime(2017,8,18) }, // Simulating multiple records
            // No records for 8/25
            new Schedule() { hours = 30, week_ending = new DateTime(2017,9,1) },
        }
    };
    // Need a start/end date so you can generate missing weeks
    var startDate = new DateTime(2017, 8, 11);
    var endDate = new DateTime(2017, 9, 1);
    // Enumerate schedules from db
    var schedules = db.Schedules // Add any other criteria besides date logic
        .Where(m => m.week_ending >= startDate && m.week_ending <= endDate)
        .GroupBy(m => m.week_ending)
        .Select(m => new Schedule() { week_ending = m.Key, hours = m.Sum(s => s.hours) })
        .AsEnumerable();
    // Add missing dates
    var results = Enumerable.Range(0, 1 + endDate.Subtract(startDate).Days)
        .Select(m => startDate.AddDays(m))
        .Where(m => m.DayOfWeek == DayOfWeek.Friday) // Only end of week
        .Where(m => schedules.Any(s => s.week_ending == m) == false) // Add missing weeks
        .Select(m => new Schedule() { week_ending = m, hours = 0 })
        .Union(schedules)
        .OrderBy(m => m.week_ending);
    // Enumerate the ordered schedules matching your criteria
    var data = new
    {
        week = results.Select(m => m.week_ending),
        hours = results.Select(m => m.hours)
    };
