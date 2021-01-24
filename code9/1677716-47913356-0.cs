    var result = db.Projects
             .Include(p => p.Department)
             .Include(p => p.ProjectPhases)
             .Include(p => p.Notes)
             .Where(x => x.ProjectPhases.Where(pp =>pp.IsActive))
             .AsQueryable<Project>();
