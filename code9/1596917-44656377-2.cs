    TaskLegs = group
        .GroupBy(x=>x.TaskId)
        .Select(y => new {
            TaskId = y.Key, 
            AssignedTo = y.Select(z => z.AssignedTo)
        })
        .OrderBy(y=>y.TaskId)
