    var projects = multi.Read<ProjectDto>();
    var projectAct = multi.Read<ProjectActivity>();
    foreach (var project in projects)
    {
       project.ProjectActivities = new List<ProjectActivity>();                        
       project.ProjectActivities.AddRange(projectAct.Where(x => x.ProjectId == project.ProjectId));
    }
