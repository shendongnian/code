    var todos = 
        session
            .Query<Todo>()
            .Fetch(t => t.Priority)
            .Select(t => 
                new {
                   t.ID,
                   t.Name,
                   Priority = new {
                       t.Priority.Id,
                       t.Prioriry.Name}
                })
            .ToList();
    return new JsonResult(todos);
