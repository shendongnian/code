    var query = 
            ctx.Projects
                .Include(p => p.Versions)
                .Where(p => p.Id.Equals(projectId))
                .Select(
                    new Project
                    {
                        Name     = p.Name,
                        Type     = p.Type,
                        Id       = p.Id,                                
                        Versions = p.Versions.Where(v => v.Version.Equals(version))
                    });
    return query.FirstOrDefault();
