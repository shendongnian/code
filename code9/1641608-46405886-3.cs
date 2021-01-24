    var found = db.MyEntity
        .OrderByDescending(c => c.CreationTime)
        .Where(c => c.ParameterColumn == parameter)
        .Select(c => new { c.CreationTime })
        .First();
