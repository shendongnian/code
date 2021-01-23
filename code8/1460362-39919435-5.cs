    var projects = (from proj in db.Projects.Where()
    
                    join t in db.Tasks on t.ProjectId equals proj.ProjectId into tasks
                    from task in t.DefaultIfEmpty()
    
                    join s in db.Tasks on s.TaskId equals task.Id into subtasks
                    from subtask in subtasks.DefaultIfEmpty()
    
                    select new 
                    {
                        ProjectId = proj.ProjectId,
                        TaskId = task.Id,
                        SubtaskId = subtask.Id
    
                    }).ToList(); // 1 query
    
    // etc
    // proceed with creating hierarchy structure using GroupBy
