    var result = db.Projects
             .Include(p => p.Department)
             .Include(p => p.ProjectPhases)
             .Include(p => p.Notes)
             .Where(it => it.ProjectPhases.All(a=>a.IsActive))
             .AsQueryable<Project>();
