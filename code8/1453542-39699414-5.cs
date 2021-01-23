    var result = schedules
        // First you join the three tables
        .Join(dates, s => s.DateId, d => d.DateId, (s, d) => new {s, d})
        .Join(tasks, s => s.s.TaskId, t => t.TaskId, (sd, t ) => new { Person = sd.s, Date = sd.d, Task = t })
        // Then you Group by the person name
        .GroupBy(j => j.Person.Name)
        // Finally you compose the final object extracting from the list of task the correct task for the current day
        .Select(group => new
        {
            Person = group.Key,
            Monday = group.Where(g => g.Date.DateId == 1).Select(g => g.Task.Desc).FirstOrDefault(),
            Tuesday = group.Where(g => g.Date.DateId == 2).Select(g => g.Task.Desc).FirstOrDefault(),
            Wednesday = group.Where(g => g.Date.DateId == 3).Select(g => g.Task.Desc).FirstOrDefault(),
            Thursday = group.Where(g => g.Date.DateId == 4).Select(g => g.Task.Desc).FirstOrDefault(),
            Friday = group.Where(g => g.Date.DateId == 5).Select(g => g.Task.Desc).FirstOrDefault()
        })
        .ToList();
