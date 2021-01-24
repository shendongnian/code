    var todos = 
        session
            .Query<Todo>()
            .Fetch(t => t.Priority)
            .Select(t => 
                new {
                   t.ID,
                   t.Name,
                   t.Priority
                })
            .ToList();
    return new JsonResult(todos);
