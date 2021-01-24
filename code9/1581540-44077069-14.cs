    public List<(ICourse Course, List<ISession> Sessions)> 
        GetInRangeSessions(IEnumerable<ICourse> courses) 
        =>
            courses
            .Select(c =>
                (Course: c, Sessions: c.Sessions.Where(session => session.InRange).ToList())
            )
            .ToList();
