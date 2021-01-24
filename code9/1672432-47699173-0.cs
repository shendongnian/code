    var data = _context.Task
    .Select(x => new ViewTask
    {
        Id = x.Id,
        Title = x.Title,
        Last_Status = x.Progress.MaxBy(y => y.Update).Status,
        Last_Update = x.Progress.MaxBy(y => y.Update).Update
     }).ToList();
