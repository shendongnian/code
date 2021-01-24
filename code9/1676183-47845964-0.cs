    var skip = (pageNumber - 1) * pageSize;
    var take = pageSize;
    var query = db.Users
        .AsNoTracking()
        .Include("Roles")
        .AsQueryable();
    
    if (!string.IsNullOrEmpty(username))
    {
        var username = inputParam.UserName.ToLower();
        query.Where(u => u.UserName.ToLower().Contains(username));
    }
    
    if (roles.Count > 0)
    {
        var roles = db.Roles
            .AsNoTracking()
            .Where(r => inputParam.Roles.Contains(r.Name))
            .Select(r => r.Id)
            .ToList();
        query.Where(u => u.Roles.Any(r => roles.Contains(r.Id)));
    }
    
    var total = query.Count();
    var result = query
        .Skip(skip)
        .Take(take)
        .OrderBy(u => u.Id)
        .Select(...)
        .ToList();
