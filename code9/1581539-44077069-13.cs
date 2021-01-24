    results.Select(c => 
        new Tuple<ICourse, List<ISession>>(
            c, 
            c.Sessions.Where(session => session.InRange).ToList()
        ))
    .Where(t => t.Item2.Any())
    .ToList();
