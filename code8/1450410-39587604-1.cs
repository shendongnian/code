    var query =
      from timeEntry in TimeEntries
      where timeEntry.DateEntity >= dateStart && timeEntry.DateEntity <= dateEnd
      select new {
        User = timeEntry.User.FirstName + " "+timeEntry.User.LastName,
        Project = timeEntry.Task.Project.ProjectName,
        ProjectId = timeEntry.Task.ProjectID,
        HoursEntered = timeEntry.HoursEntered
      }
    
    var localRows = query.ToList();
    
    var groups = localRows.GroupBy(x => x.Project);
    
    var projects = groups.Select(g => new {
      Project = g.Key,
      Hours = g.Sum(x => x.HoursEntered),
      Users = g.Select(x => x.User).Distinct().ToList()
    }).ToList();
