    var projects = db.Projects.Where().Order().Skip().Take().Select().ToList(); // 1 query
    var projectIds = projects.Select(x => x.ProjectId).ToList();
    
    var tasks = db.Tasks.Where(x => projectIds.Contains(x.ProjectId)).Select().ToList(); // 1 query
    var taskIds = tasks.Select(x => x.TaskId).ToList();
    
    var subtasks = db.SubTasks.Where(x => taskIds.Contains(x.TaskId)).Select().ToList() // 1 query
    
    foreach(var project in projects)
    {
        project.Tasks = tasks.Where(x => x.ProjectId == project.ProjectId).ToList();
    
        // etc
        // complete hierarchy structure
    }
