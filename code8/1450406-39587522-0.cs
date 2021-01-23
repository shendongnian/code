    var query = (from timeEntry in TimeEntries
            join task in Tasks on timeEntry.TaskID equals task.TaskID
            join project in Projects on task.ProjectID equals project.ProjectID
            where timeEntry.DateEntity >= dateStart && timeEntry.DateEntity <= dateEnd
            group timeEntry by new { proyect.ProjectID, proyect.ProjectName } into g
            select new {
            TimeEntries = g.ToArray(),
            Project = g.Key.ProjectName ,
            ProjectId = g.Key.ProjectID,
            });
