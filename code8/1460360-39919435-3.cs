    var projects = (from proj in db.Projects.Where()
    
                    join t in db.Tasks on t.ProjectId equals proj.ProjectId into tasks
                    from task in t.DefaultIfEmpty()
    
                    join s in db.SubTasks on s.TaskId equals task.TaskId into subtasks
                    from subtask in subtasks.DefaultIfEmpty()
    
                    select new 
                    {
                        ProjectId = proj.ProjectId,
                        TaskId = task.TaskId,
                        SubtaskId = subtask.SubtaskId
    
                    }).ToList(); // 1 query
    
    // etc
    // proceed with creating hierarchy structure using GroupBy
