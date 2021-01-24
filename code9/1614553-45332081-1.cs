    var result = (
        from c in Collections
        from s in Sprints.Where(s => s.IdCollection == c.IdCollection)
        from dd in DeployDocuments.Where(dd => dd.IdSprint == s.IdSprint).DefaultIfEmpty()
        select new { c, s, dd } )
    .GroupBy(g => new { g.c.TxCollectionName, g.s.SprintNumber })
    .Select(s => new { s.Key.TxCollectionName, s.Key.SprintNumber, NumProjects = s.Count() };
